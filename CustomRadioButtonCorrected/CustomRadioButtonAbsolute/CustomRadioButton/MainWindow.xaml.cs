using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomRadioButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new CommandViewModel();
        }
        public void Radio1_CommandChanged(object source, EventArgs args)
        {
            var par = source as CustRadio;
            CommandViewModel.Status=par.Text;
            if (par.IsChecked)
            {
                if (CommandViewModel.Status == "Papaya")
                {
                    CommandViewModel.ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\charlesdeluvio-yPI38imbQSI-unsplash.jpg";
                }
                else if (CommandViewModel.Status == "Cherry")
                {
                    CommandViewModel.ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\mae-mu-vbAEHCrvXZ0-unsplash.jpg";
                }
                else if (CommandViewModel.Status == "Pineapple")
                {
                    CommandViewModel.ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\fernando-andrade-nAOZCYcLND8-unsplash.jpg";
                }
                else if (CommandViewModel.Status == "Orange")
                {
                    CommandViewModel.ImgSrc = @"C:\Users\ChellaDhuraiSonaimut\Downloads\mae-mu-U1iYwZ8Dx7k-unsplash.jpg";
                }
                SelectedRad.Text = CommandViewModel.Status;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(CommandViewModel.ImgSrc);
                logo.EndInit(); // Getting the exception here
                Img.Source = logo;
            }
        }





        //private void Radio_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    SelectedRad.Text=sender.ToString();
        //}
    }
}
