using Utils;

namespace LanguageWidget.ViewModel
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
                ObjectResult.LanguageName = _name;
                NotifyPropertyChanged(() => this.Name);
            }
        }

        public LanguageReference.Language ObjectResult { get; set; }

        public EditorViewModel(LanguageReference.Language language)
        {
            ObjectResult = new LanguageReference.Language();
            ObjectResult.LanguageId = language.LanguageId;
            ObjectResult.LanguageName = language.LanguageName;
            this.Name = ObjectResult.LanguageName;
        }
    }
}
