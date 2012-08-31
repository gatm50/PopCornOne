using System.Windows;
using LanguageWidget.Utils;
using Utils.ModalDialog;

namespace AutorWidget
{
    public partial class EditorWindow : IModalWindow
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtAutorName.Text == "Insert Autor Name")
                return;

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

