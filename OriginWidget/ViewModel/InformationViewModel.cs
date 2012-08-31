using Utils;

namespace OriginWidget.ViewModel
{
    public class InformationViewModel: BaseViewModel
    {
        private string _message;
        public string Message 
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyPropertyChanged(() => this.Message);
            }
        }
    }
}
