using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomRadioButton
{
    internal class CommandViewModel:INotifyPropertyChanged
    {
        private static string status;
        public static string Status { get { return status; } set { status = value; } }
        private string unCheckStatus;
        public string UnCheckStatus { get { return unCheckStatus; } set { unCheckStatus = value;NotifyChange(nameof(UnCheckStatus)); } }
        private static string imgSrc = null;
        public static  string ImgSrc { get { return imgSrc; } set { imgSrc = value; } }
        private string unCheckImg;
        public string UnCheckImg { get { return unCheckImg; } set { unCheckImg = value; NotifyChange(nameof(unCheckImg)); } }
        public ICommand RadCommand { get; set; }   
        public ICommand UnRadCommand { get; set; }
        public CommandViewModel() 
        {
            RadCommand = new RelayCommand(ExecuteCommand, CanExecuteCommand);
            UnRadCommand = new RelayCommand(ExecuteUnCheckCommand, CanExecuteUnCheckCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyChange(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CanExecuteCommand(object parameter)
        {
            var par = parameter as CustRadio;
            string tempString = par.Text;
            if((tempString != UnCheckStatus || Status is null))
            {
                CommandViewModel.Status = tempString;
                return true;
            }
            return false;

            //return true;
        }
        private void ExecuteCommand(object parameter)
        {
            var par = parameter as CustRadio;
            if (par.IsChecked)
            {
                if (Status == "Papaya")
                {
                    ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\charlesdeluvio-yPI38imbQSI-unsplash.jpg";
                }
                else if (Status == "Cherry")
                {
                    ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\mae-mu-vbAEHCrvXZ0-unsplash.jpg";
                }
                else if (Status == "Pineapple")
                {
                    ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\fernando-andrade-nAOZCYcLND8-unsplash.jpg";
                }
                else if (Status == "Orange")
                {
                    ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\mae-mu-U1iYwZ8Dx7k-unsplash.jpg";
                }
            }
        }
        private bool CanExecuteUnCheckCommand(object parameter)
        {

            var par = parameter as CustRadio;
            string tempString = par.Text;
            if ((UnCheckStatus != Status || UnCheckStatus is null))
            {
                UnCheckStatus = Status;
                return true;
            }
            return false;
        }

        private void ExecuteUnCheckCommand(object parameter)
        {
            var par = parameter as CustRadio;
                if (UnCheckStatus == "Papaya")
                {
                    UnCheckImg = @"C:\Users\ChellaDhuraiSonaimut\Downloads\charlesdeluvio-yPI38imbQSI-unsplash.jpg";
                }
                else if (UnCheckStatus == "Cherry")
                {
                    UnCheckImg = @"C:\Users\ChellaDhuraiSonaimut\Downloads\mae-mu-vbAEHCrvXZ0-unsplash.jpg";
                }
                else if (UnCheckStatus == "Pineapple")
                {
                    UnCheckImg = @"C:\Users\ChellaDhuraiSonaimut\Downloads\fernando-andrade-nAOZCYcLND8-unsplash.jpg";
                }
                else if (UnCheckStatus == "Orange")
                {
                    UnCheckImg = @"C:\Users\ChellaDhuraiSonaimut\Downloads\mae-mu-U1iYwZ8Dx7k-unsplash.jpg";
                }
        }

    }
}
