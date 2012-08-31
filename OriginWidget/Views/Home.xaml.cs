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
using System.Windows.Navigation;
using OriginWidget.ViewModel;

namespace OriginWidget
{
    public partial class Home : Page
    {
        private HomeViewModel _viewModel;
        public Home()
        {
            InitializeComponent();
            _viewModel = new HomeViewModel();
            this.DataContext = _viewModel;
        }
    }
}
