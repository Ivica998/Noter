using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Noter.Models.Commands
{
    public class EmptyCommand : ActionCommandBase, ICommand
    {
        private readonly Action _action;

        public EmptyCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

    }
}
