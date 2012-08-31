using System;
using System.Collections.ObjectModel;
using Utils;

namespace PhraseWidget.ViewModel
{
    public class TranslationEditorViewModel: BaseViewModel
    {
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                NotifyPropertyChanged(() => this.Content);
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged(() => this.Description);
            }
        }

        private int _language;
        public int Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                NotifyPropertyChanged(() => this.Language);
            }
        }

        public ObservableCollection<LanguageReference.Language> Languages { get; set; }
        public TranslationReference.Translation TranslationResult { get; set; }
        private LanguageReference.LanguageServiceClient _languageClient;
        private PhraseReference.Phrase _currentPhraseSelected;

        public TranslationEditorViewModel(PhraseReference.Phrase phrase, TranslationReference.Translation translation)
        {
            this.TranslationResult = new TranslationReference.Translation();
            this.Languages = new ObservableCollection<LanguageReference.Language>();

            _currentPhraseSelected = phrase;
            this.Content = translation.TranslationContent;
            this.Description = translation.TranslationDescription;
            this.Language = translation.LanguageId;
            this.TranslationResult.TranslationId = translation.TranslationId;

            _languageClient = new LanguageReference.LanguageServiceClient();
            _languageClient.DisplayLanguagesCompleted += DisplayListLanguageComplete;
            _languageClient.DisplayLanguagesAsync();
        }

        private void DisplayListLanguageComplete(object sender, LanguageReference.DisplayLanguagesCompletedEventArgs e)
        {
            this.Languages.Clear();

            foreach (var item in e.Result)
                this.Languages.Add(item);
            this.Language = this.Language;
        }

        public void CreateATranslation()
        {
            this.TranslationResult.PhraseId = _currentPhraseSelected.phraseId;
            this.TranslationResult.TranslationContent = this.Content;
            this.TranslationResult.TranslationFirstLetter = this.Content[0].ToString();
            this.TranslationResult.TranslationDescription = this.Description;
            this.TranslationResult.Lexicon = "";
            this.TranslationResult.LanguageId = Convert.ToInt32(Language);
        }
    }
}
