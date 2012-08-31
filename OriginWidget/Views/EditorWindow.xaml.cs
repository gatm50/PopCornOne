using System.Windows;
using LanguageWidget.Utils;
using Utils.ModalDialog;

namespace OriginWidget
{
    public partial class EditorWindow : IModalWindow
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtLanguageName.Text == "Insert Language Name")
                return;

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

