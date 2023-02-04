using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Brush OuterStroke { get { return _outerStroke; } set { _outerStroke = value;NotifyChange(nameof(OuterStroke)); } }
        private Brush _innerStroke;
        public Brush InnerStroke { get { return _innerStroke; } set { _innerStroke = value; NotifyChange(nameof(InnerStroke)); } }
        public string Text { get; set; }


        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value);NotifyChange(nameof(IsChecked)); }
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



        public ICommand UnChecked
        {
            get { return (ICommand)GetValue(UnCheckedProperty); }
            set { SetValue(UnCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnCheckedProperty =
            DependencyProperty.Register("UnChecked", typeof(ICommand), typeof(CustRadio), new PropertyMetadata(null));




        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in RadioList)
            {
                if (this.GroupName == item.GroupName && /*item.selectEllipse.Visibility == Visibility.Visible*/ item.IsChecked)
                {
                    item.IsChecked = false;
                    item.selectEllipse.Visibility = Visibility.Hidden;
                    if(UnChecked.CanExecute(item))
                    {
                        UnChecked.Execute(item);
                    }
                }
            }
            selectEllipse.Visibility = Visibility.Visible;
            IsChecked = true;
            if (MyCommand.CanExecute(this))
            {
                //MyCommand.Execute(this);
                OnCommandChanged();
            }
            //CommandChanged?.Invoke(this, EventArgs.Empty);
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
        public delegate void CommandEventHandler(object source, EventArgs args);
        public event CommandEventHandler CommandChanged;
        protected void OnCommandChanged()
        {
            if (this.CommandChanged != null)
            {
                this.CommandChanged(this, EventArgs.Empty);
            }
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
