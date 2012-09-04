using Utils;
using System.Collections.ObjectModel;
using System;
using PhraseWidget.Model;

namespace PhraseWidget.ViewModel
{
    public class EditorViewModel : BaseViewModel
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

        private int _origin;
        public int Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
                NotifyPropertyChanged(() => this.Origin);
            }
        }

        private int _autor;
        public int Autor
        {
            get
            {
                return _autor;
            }
            set
            {
                _autor = value;
                NotifyPropertyChanged(() => this.Autor);
            }
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get
            {
                return _validationMessage;
            }
            set
            {
                _validationMessage = value;
                NotifyPropertyChanged(() => this.ValidationMessage);
            }
        }

        private string _lexicon;
        public string Lexicon
        {
            get
            {
                return _lexicon;
            }
            set
            {
                _lexicon = value;
                NotifyPropertyChanged(() => this.Lexicon);
            }
        }

        public ObservableCollection<LanguageReference.Language> Languages { get; set; }
        public ObservableCollection<AutorReference.Autor> Autors { get; set; }
        public ObservableCollection<OriginReference.Origin> Origins { get; set; }

        public PhraseReference.Phrase PhraseResult { get; set; }
        public TranslationReference.Translation TranslationResult { get; set; }

        private LanguageReference.LanguageServiceClient _languageClient;
        private AutorReference.AutorServiceClient _autorClient;
        private OriginReference.OriginServiceClient _originClient;

        public EditorViewModel(CompletePhrase phrase)
        {
            this.PhraseResult = new PhraseReference.Phrase();
            this.PhraseResult.phraseId = phrase.Phrase.phraseId;
            this.PhraseResult.AutorId = phrase.Phrase.AutorId;
            this.PhraseResult.OriginId = phrase.Phrase.OriginId;
            this.PhraseResult.TranslationId = phrase.Phrase.TranslationId;

            this.TranslationResult = new TranslationReference.Translation();
            this.TranslationResult.TranslationId = phrase.Translation.TranslationId;
            this.TranslationResult.LanguageId = phrase.Translation.LanguageId;
            this.TranslationResult.Lexicon = phrase.Translation.Lexicon;
            this.TranslationResult.TranslationContent = phrase.Translation.TranslationContent;
            this.TranslationResult.TranslationDescription = phrase.Translation.TranslationDescription;
            this.TranslationResult.TranslationFirstLetter = phrase.Translation.TranslationFirstLetter;
            this.TranslationResult.PhraseId = phrase.Translation.PhraseId;
            this.TranslationResult.PhraseByDefault = phrase.Translation.PhraseByDefault;

            this.Languages = new ObservableCollection<LanguageReference.Language>();
            this.Autors = new ObservableCollection<AutorReference.Autor>();
            this.Origins = new ObservableCollection<OriginReference.Origin>();
            this.ValidationMessage = string.Empty;

            _languageClient = new LanguageReference.LanguageServiceClient();
            _languageClient.DisplayLanguagesCompleted += DisplayListLanguageComplete;
            _languageClient.DisplayLanguagesAsync();

            _autorClient = new AutorReference.AutorServiceClient();
            _autorClient.DisplayAutorsCompleted += DisplayListAutorComplete;
            _autorClient.DisplayAutorsAsync();

            _originClient = new OriginReference.OriginServiceClient();
            _originClient.DisplayOriginsCompleted += DisplayListOriginComplete;
            _originClient.DisplayOriginsAsync();
        }

        private void DisplayListLanguageComplete(object sender, LanguageReference.DisplayLanguagesCompletedEventArgs e)
        {
            this.Languages.Clear();

            foreach (var item in e.Result)
                this.Languages.Add(item);

            this.UpdateValues();
        }

        private void DisplayListAutorComplete(object sender, AutorReference.DisplayAutorsCompletedEventArgs e)
        {
            this.Autors.Clear();

            foreach (var item in e.Result)
                this.Autors.Add(item);

            this.UpdateValues();
        }

        private void DisplayListOriginComplete(object sender, OriginReference.DisplayOriginsCompletedEventArgs e)
        {
            this.Origins.Clear();

            foreach (var item in e.Result)
                this.Origins.Add(item);

            this.UpdateValues();
        }

        public TranslationReference.Translation CreateATranslation()
        {
            TranslationReference.Translation temporalTranslation = new TranslationReference.Translation();
            temporalTranslation.TranslationId = this.TranslationResult.TranslationId;
            temporalTranslation.TranslationContent = this.Content;
            temporalTranslation.TranslationFirstLetter = this.Content[0].ToString();
            temporalTranslation.TranslationDescription = this.Description;
            temporalTranslation.Lexicon = this.Lexicon;
            temporalTranslation.LanguageId = Convert.ToInt32(Language);
            temporalTranslation.PhraseId = this.TranslationResult.PhraseId;
            temporalTranslation.PhraseByDefault = this.TranslationResult.PhraseByDefault;
            return temporalTranslation;
        }

        public void CreateAPhrase()
        {
            PhraseReference.Phrase temporalPhrase = new PhraseReference.Phrase();
            temporalPhrase.phraseId = this.PhraseResult.phraseId;
            temporalPhrase.AutorId = Convert.ToInt32(this.Autor);
            temporalPhrase.OriginId = this.Origin;
            temporalPhrase.TranslationId = this.PhraseResult.TranslationId;
            this.PhraseResult = temporalPhrase;
            this.TranslationResult = this.CreateATranslation();
        }

        public void UpdateValues()
        {
            this.Autor = this.PhraseResult.AutorId;
            this.Origin = this.PhraseResult.OriginId;
            this.Language = this.TranslationResult.LanguageId;
            this.Content = this.TranslationResult.TranslationContent;
            this.Description = this.TranslationResult.TranslationDescription;
            this.Lexicon = this.TranslationResult.Lexicon;
        }

        public bool ValidateData()
        {
            bool result = true;
            if (this.Content == null || this.Content== string.Empty)
                result= false;
            if (this.Description == null || this.Description == string.Empty)
                result = false;
            if (this.Lexicon == null || this.Lexicon == string.Empty)
                result = false;
            if (this.Language == 0)
                result = false;
            if (this.Origin == 0)
                result = false;
            if (this.Autor == 0)
                result = false;
            if (!result)
                this.ValidationMessage = "All the fields are required.";
            return result;
        }
    }
}
