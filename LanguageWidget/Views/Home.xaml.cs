using System.Windows.Controls;
using LanguageWidget.ViewModel;

namespace LanguageWidget
{
    public partial class Home : Page
    {
        private HomeViewModel _viewModel;
        public Home()
        {
            _viewModel = new HomeViewModel();
            this.DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
