using System.Windows;
using LanguageWidget.Utils;
using Utils.ModalDialog;

namespace PhraseWidget
{
    public partial class InformationWindow : IModalWindow
    {
        public InformationWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

