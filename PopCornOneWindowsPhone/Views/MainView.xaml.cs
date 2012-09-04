using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PopCornOneCoreWindowsPhone.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Views;

namespace PopCornOneWindowsPhone.Views
{
    //public partial class MainView : PhoneApplicationPage
    public partial class MainView : BaseMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/ResultView.xaml?msg=" + this.ViewModel.Search, UriKind.Relative));
        }
    }

    public class BaseMainView : MvxPhonePage<MainViewModel> { }
}