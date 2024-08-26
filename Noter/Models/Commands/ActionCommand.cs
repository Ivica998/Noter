using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Noter.Models.Commands
{
    public class ActionCommand : ActionCommandBase, ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _condition;

        public ActionCommand(Action<object> action = null, Predicate<object> condition = null)
        {
            _action = action;
            _condition = condition;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _condition?.Invoke(parameter) ?? true;
        }

    }
}
