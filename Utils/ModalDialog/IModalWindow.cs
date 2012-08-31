using System;

namespace Utils.ModalDialog
{
    public interface IModalWindow
    {
        bool? DialogResult { get; set; }
        event EventHandler Closed;
        void Show();
        object DataContext { get; set; }
        void Close();
    }
}
