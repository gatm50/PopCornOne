
namespace Utils.MessageBox
{
    public interface IMessageBoxService
    {
        GenericMessageBoxResult Show(string message, string caption, GenericMessageBoxButton buttons);
        void Show(string message, string caption);
    }

    public enum GenericMessageBoxButton
    {
        Ok,
        OkCancel
    }

    public enum GenericMessageBoxResult
    {
        Ok,
        Cancel
    }
}
