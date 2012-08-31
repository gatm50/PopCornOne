using Utils;

namespace OriginWidget.ViewModel
{
    public class EditorViewModel: BaseViewModel
    {
        private string _name;
        public string Name 
        {
            get 
            {
                return _name;
            }
            set 
            {
                _name = value;
                ObjectResult.OriginName = _name;
                NotifyPropertyChanged(() => this.Name);
            }
        }

        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                ObjectResult.OriginUrl = _url;
                NotifyPropertyChanged(() => this.Url);
            }
        }

        public OriginReference.Origin ObjectResult { get; set; }

        public EditorViewModel(OriginReference.Origin origin)
        {
            ObjectResult = new OriginReference.Origin();
            ObjectResult.OriginId = origin.OriginId;
            ObjectResult.OriginName = origin.OriginName;
            ObjectResult.OriginUrl = origin.OriginUrl;
            this.Name = ObjectResult.OriginName;
            this.Url = ObjectResult.OriginUrl;
        }
    }
}
