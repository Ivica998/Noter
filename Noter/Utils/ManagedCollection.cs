using Noter.Models;
using Noter.Models.Extra;
using Noter.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Noter.Utils
{
    public class ManagedCollection<T> : INotifyPropertyChanged where T : class, ISaveTXT, new()
    {
        private bool handleClear = true;
        public object Extra { get; set; }
        public event Func<object,string,bool> ExtraAddValidation;
        public event CollectionChangedEventHandler PreCollectionChanged;
        public event CollectionChangedEventHandler CollectionChanged;
        public event CollectionClearedEventHandler CollectionCleared;
        public ObservableCollection<T> List { get; set; } = new ObservableCollection<T>();
        public Dictionary<string, T> Map { get; set; } = new Dictionary<string, T>();
        public object Owner { get; set; }
        public ManagedCollection(object owner)
        {
            Owner = owner;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private T active;
        public T Active
        {
            get => active;
            set
            {
                if (active != value)
                {
                    if(active != null)
                        active.PreValChange(Owner);
                    active = value;
                    if (active != null)
                    {
                        Add(active.Name, active);
                        active.PostValChange(Owner);
                        OnPropertyChanged();
                    }
                }
            }
        }
        public T this[string key]
        {
            get => Map[key];
            set => Map[key] = value;
        }
        public int Count => List.Count;
        public bool IsReadOnly => false;
        public void Add(string key, T item)
        {
            if (Map.ContainsKey(key) || ExtraAddValidation?.Invoke(this, key) == false)
                return;
            List.Add(item);
            Map.Add(key, item);
            handleClear = false;
            PreCollectionChanged?.Invoke(this, new CollectionChangedEventArgs() { Command = ManagedCollectionCommand.Add, Key = key });
            handleClear = true;
            CollectionChanged?.Invoke(this, new CollectionChangedEventArgs() { Command = ManagedCollectionCommand.Add, Key = key });
        }
        public void Clear()
        {
            List.Clear();
            Map.Clear();
            active = null;
            CollectionChanged?.Invoke(this, new CollectionChangedEventArgs() { Command = ManagedCollectionCommand.Clear });
            OnCollectionCleared(handleClear);
        }
        public bool ContainsValue(T item)
        {
            return Map.ContainsValue(item);
        }
        public bool ContainsKey(string key)
        {
            return key != null && Map.ContainsKey(key);
        }
        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return Map.GetEnumerator();
        }
        public bool Remove(string key)
        {
            if (!ContainsKey(key))
                return false;
            PreCollectionChanged?.Invoke(this, new CollectionChangedEventArgs() { Command = ManagedCollectionCommand.Remove, Key = key });
            List.Remove(Map[key]);
            Map.Remove(key);
            CollectionChanged?.Invoke(this, new CollectionChangedEventArgs() { Command = ManagedCollectionCommand.Remove, Key = key });
            if (List.Count == 0)
                OnCollectionCleared(handleClear);
            return true;
        }

        internal void AddList(List<T> list)
        {
            foreach (var item in list)
            {
                Add(item.Name, item);
            }
        }

        public int IndexOf(string key)
        {
            return List.IndexOf(Map[key]);
        }

        internal void SetActive(int index)
        {
            if (List.Count == 0)
                return;
            if (index < 0 || index >= List.Count)
                index = 0;
            Active = List[index];
            //mainWindow.cbSource.SelectedIndex = index;
        }

        internal void SetActive(string key)
        {
            if (ContainsKey(key))
                Active = Map[key];
            //mainWindow.cbSource.SelectedIndex = index;
        }

        private void OnCollectionCleared(bool should)
        {
            if(should)
                CollectionCleared?.Invoke(this, CollectionClearedEventArgs.Empty);
        }
    }
}
