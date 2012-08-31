using Utils;

namespace AutorWidget.ViewModel
{
    public class EditorViewModel : BaseViewModel
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
                ObjectResult.AutorName = _name;
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
                ObjectResult.AutorUrl = _url;
                NotifyPropertyChanged(() => this.Url);
            }
        }

        public AutorReference.Autor ObjectResult { get; set; }

        public EditorViewModel(AutorReference.Autor autor)
        {
            ObjectResult = new AutorReference.Autor();
            ObjectResult.AutorId = autor.AutorId;
            ObjectResult.AutorName = autor.AutorName;
            ObjectResult.AutorUrl = autor.AutorUrl;
            this.Name = ObjectResult.AutorName;
            this.Url = ObjectResult.AutorUrl;
        }
    }
}
