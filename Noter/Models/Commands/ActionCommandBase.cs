using System;

namespace Noter.Models.Commands
{
    public class ActionCommandBase
    {
        public event EventHandler CanExecuteChanged;
    }
}