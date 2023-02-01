using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for CustRadio.xaml
    /// </summary>
    public partial class CustRadio : UserControl,INotifyPropertyChanged
    {
        public static ObservableCollection<CustRadio> RadioList = new ObservableCollection<CustRadio>();
        public CustRadio()
        {
            InitializeComponent();
            this.DataContext = this;
            RadioList.Add(this);
            this.Loaded += Radio_Loaded;

        }

        private string _groupName;
        public string GroupName { get { return _groupName; } set { _groupName = value; } }

        private Brush _outerStroke;
        public Brush OuterStroke { get { return _outerStroke; } set { _outerStroke = value; } }
        private Brush _innerStroke;
        public Brush InnerStroke { get { return _innerStroke; } set { _innerStroke = value; } }
        public string Text { get; set; }


        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(CustRadio), new PropertyMetadata(true));


        public ICommand MyCommand
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        public static readonly DependencyProperty CommandProperty =
                    DependencyProperty.Register("MyCommand", typeof(ICommand), typeof(CustRadio), new PropertyMetadata(null));


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool Checked = false;
            foreach (var item in RadioList)
            {
                if (this.GroupName == item.GroupName && item.selectEllipse.Visibility == Visibility.Visible)
                {
                    Checked = true;
                }
            }
            if (Checked)
            {
                selectEllipse.Visibility = Visibility.Hidden;
                IsChecked = false;
            }
            else
            {
                selectEllipse.Visibility = Visibility.Visible;
                IsChecked = true;
            }
            MyCommand.Execute(this);
            //IsChecked=IsChecked == true ? false : true;//ShortHand ternary
            //if (IsChecked == true)
            //{
            //    //selectEllipse.Visibility = Visibility.Hidden;//Have been done through Data Triggers
            //    IsChecked = false;
            //}
            //else
            //{
            //    //selectEllipse.Visibility = Visibility.Visible;
            //    IsChecked = true;
            //}

            //Simulated Radio Button         

        }
        private void Radio_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.OuterStroke==null || this.InnerStroke==null)
            {
                bool isExist = false;
                foreach(var item in RadioList)
                {
                    if(item.GroupName==this.GroupName)
                    {
                        isExist = true;
                        this.OuterStroke = item.OuterStroke;
                        this.InnerStroke = item.InnerStroke;
                        NotifyChange(nameof(OuterStroke));
                        NotifyChange(nameof(InnerStroke));
                        break;
                    }
                }
                if(!isExist)
                {
                    this.OuterStroke = new SolidColorBrush(Colors.Blue);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
