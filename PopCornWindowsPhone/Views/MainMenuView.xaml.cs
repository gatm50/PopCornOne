using Cirrious.MvvmCross.WindowsPhone.Views;
using PopCornOneCoreWindowsPhone.ViewModels;

namespace PopCornWindowsPhone.Views
{
    public partial class MainMenuView : BaseMainMenuView
    {
        public MainMenuView()
        {
            InitializeComponent();
        }
    }

    public class BaseMainMenuView : MvxPhonePage<MainMenuViewModel> { }
}