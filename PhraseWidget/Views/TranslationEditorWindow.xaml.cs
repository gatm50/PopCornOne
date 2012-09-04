using System.Windows;
using PhraseWidget.ViewModel;
using Utils.ModalDialog;

namespace PhraseWidget
{
    public partial class TranslationEditorWindow : IModalWindow
    {
        private TranslationEditorViewModel _viewModel;
        public TranslationEditorWindow(TranslationEditorViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            this.DataContext = this._viewModel;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateData())
            {
                _viewModel.CreateATranslation();
                this.DialogResult = true;
            }
            else
                return;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

