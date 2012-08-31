using System.Windows.Controls;
using PhraseWidget.Model;
using PhraseWidget.ViewModel;

namespace PhraseWidget
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

        private void dtgPhrases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
                _viewModel.LoadTranslations(e.AddedItems[0] as CompletePhrase);
        }
    }
}
