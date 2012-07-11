using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using PopCornOneCoreWindowsPhone.ViewModels;

namespace PopCornOneCoreWindowsPhone.ApplicationObjects
{
    public class StartApplicationObject : 
        MvxApplicationObject
        , IMvxStartNavigation

    {
        public void Start()
        {
            this.RequestNavigate<MainMenuViewModel>();
        }

        public bool ApplicationCanOpenBookmarks
        {
            get { return true; }
        }


    }
}
