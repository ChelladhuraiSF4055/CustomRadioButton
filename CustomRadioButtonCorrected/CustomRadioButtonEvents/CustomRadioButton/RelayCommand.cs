using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomRadioButton
{
    internal class RelayCommand : ICommand
    {
        Action<object> _action { get; set; }
        Func<object,bool> _func { get; set; }
        public RelayCommand(Action<object>execute,Func<object,bool>canExecute)
        {
            _action = execute;
            _func=canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _func(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
