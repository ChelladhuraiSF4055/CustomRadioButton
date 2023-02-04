using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomRadioButton
{
    class UnCheck
    {
        private string status;
        public string Status { get { return status; } set { status = value; NotifyChange("Status"); } }
        public ICommand Check { get; set; }
        private bool _canCheck = false;

        public bool CanCheck { get { return _canCheck; } set { _canCheck = value; } }
        public UnCheck()
        {
            //RadCommand = new RelayCommand(ExecuteCommand, CanExecuteCommand);
            Check = new RelayCommand(ExecuteCommand, CanExecuteCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CanExecuteCommand(object parameter)
        {
            //var par = parameter as CustRadio;
            //if (par.IsChecked==false)
            //    return false;
            //return true;
            return true;
        }
        private void ExecuteCommand(object parameter)
        {
            var par = parameter as CustRadio;
            Status = par.Text.ToString() + " becomes " + par.IsChecked.ToString();
            NotifyChange(nameof(Status));
            if (par.IsChecked == true)
            {
                CanCheck = false;
            }
            else
            {
                CanCheck = true;
            }
            NotifyChange(nameof(CanCheck));
        }

    }
}
