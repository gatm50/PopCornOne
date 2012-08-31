using System.Windows;
using LanguageWidget.Utils;
using Utils.ModalDialog;
using System;
using PhraseWidget.ViewModel;

namespace PhraseWidget
{
    public partial class EditorWindow : IModalWindow
    {
        private EditorViewModel ViewModel;
        public EditorWindow(EditorViewModel viewModel)
        {
            InitializeComponent();
            this.ViewModel = viewModel;
            this.DataContext = this.ViewModel;
        }

        protected override void OnOpened()
        {
            this.ViewModel.UpdateValues();
            base.OnOpened();
            return;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if ((this.DataContext as EditorViewModel).ValidateData())
            {
                (this.DataContext as EditorViewModel).CreateAPhrase();
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

