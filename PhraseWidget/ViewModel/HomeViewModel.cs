using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LanguageWidget.Utils;
using Utils;
using Utils.MessageBox;
using Utils.ModalDialog;
using PhraseWidget.Model;
using System.Collections.Generic;

namespace PhraseWidget.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private PhraseReference.PhraseServiceClient _phraseClient;
        private TranslationReference.TranslationServiceClient _translationClient;
        private LanguageReference.LanguageServiceClient _languageClient;
        private TranslationReference.Translation _temporalPhraseTranslation;

        private CompletePhrase _lastPhraseSelected;

        private string _searchTerm;
        public string SearchTerm
        {
            get
            {
                return _searchTerm;
            }
            set
            {
                _searchTerm = value;
                NotifyPropertyChanged(() => this.SearchTerm);
                _phraseClient.DisplayPhrasesAsync();
            }
        }
        public List<PhraseReference.Phrase> Phrases { get; set; }
        public ObservableCollection<CompletePhrase> Phrases2 { get; set; }
        public ObservableCollection<TranslationReference.Translation> Translations { get; set; }
        public ObservableCollection<CompleteTranslation> TranslationsComplete { get; set; }

        private readonly IMessageBoxService _messageBoxService;
        private readonly IModalDialogService _modalDialogService;
        private readonly IModalDialogService _informationDialogService;
        private readonly IModalDialogService _translationModalDialogService;

        public HomeViewModel()
        {
            this.Phrases = new List<PhraseReference.Phrase>() { };
            this.Phrases2 = new ObservableCollection<CompletePhrase>();
            this.Translations = new ObservableCollection<TranslationReference.Translation>();
            this.TranslationsComplete = new ObservableCollection<CompleteTranslation>();

            this.CreatePhraseCommand = new DelegateCommand(AddPhrase_Execute, AddPhrase_CanExecute);
            this.EditPhraseCommand = new DelegateCommand(EditPhrase_Execute, EditPhrase_CanExecute);
            this.DeletePhraseCommand = new DelegateCommand(DeletePhrase_Execute, DeletePhrase_CanExecute);

            this.CreateTranslationCommand = new DelegateCommand(AddTranslation_Execute, AddTranslation_CanExecute);
            this.EditTranslationCommand = new DelegateCommand(EditTranslation_Execute, EditTranslation_CanExecute);
            this.DeleteTranslationCommand = new DelegateCommand(DeleteTranslation_Execute, DeleteTranslation_CanExecute);

            _phraseClient = new PhraseReference.PhraseServiceClient();
            _phraseClient.CreatePhraseCompleted += CreatePhraseComplete;
            _phraseClient.DisplayPhrasesCompleted += DisplayListPhrasesComplete;
            _phraseClient.EditPhraseCompleted += EditPhraseComplete;
            _phraseClient.DeletePhraseCompleted += DeletePhraseComplete;

            _translationClient = new TranslationReference.TranslationServiceClient();
            _translationClient.CreateTranslationCompleted += CreateTranslationComplete;
            _translationClient.DisplayTranslationsCompleted += DisplayListTranslationComplete;
            _translationClient.DisplayTranslationsByPhraseIdCompleted += DisplayTranslationsByPhraseIdCompleted;
            _translationClient.EditTranslationCompleted += EditTranslationComplete;
            _translationClient.DeleteTranslationCompleted += DeleteTranslationComplete;

            _languageClient = new LanguageReference.LanguageServiceClient();
            _languageClient.DisplayLanguagesCompleted += DisplayListLanguageComplete;

            _phraseClient.DisplayPhrasesAsync();

            _messageBoxService = new MessageBoxService();
            _modalDialogService = new ModalDialogService();
            _informationDialogService = new ModalDialogService();
            _translationModalDialogService = new ModalDialogService();

            _temporalPhraseTranslation = new TranslationReference.Translation();
        }

        private void DisplayListPhrasesComplete(object sender, PhraseReference.DisplayPhrasesCompletedEventArgs e)
        {
            this.Phrases.Clear();
            if (_searchTerm == null)
                _searchTerm = string.Empty;
            foreach (var item in e.Result)
            {
                if (_searchTerm == string.Empty)
                    this.Phrases.Add(item);
                else
                {
                    //foreach (var translation in item.Translations)
                    //{
                    //    string temporalPhraseContentLower = translation.TranslationContent.ToLower();
                    //    string temporalSearchTermLower = _searchTerm.ToLower();

                    //    if (temporalPhraseContentLower.Contains(temporalSearchTermLower))
                    //        this.Phrases.Add(item);
                    //}
                }

            }
            _translationClient.DisplayTranslationsAsync();
        }

        private void DisplayListTranslationComplete(object sender, TranslationReference.DisplayTranslationsCompletedEventArgs e)
        {
            this.Phrases2.Clear();
            foreach (var phrase in this.Phrases)
            {
                foreach (var translation in e.Result)
                {
                    if (phrase.TranslationId == translation.TranslationId)
                    {
                        this.Phrases2.Add(new CompletePhrase(phrase, translation));
                        break;
                    }
                }
            }
        }

        private void DisplayTranslationsByPhraseIdCompleted(object sender, TranslationReference.DisplayTranslationsByPhraseIdCompletedEventArgs e)
        {
            this.Translations.Clear();
            foreach (var translation in e.Result)
                this.Translations.Add(translation);
            _languageClient.DisplayLanguagesAsync();
        }

        private void DisplayListLanguageComplete(object sender, LanguageReference.DisplayLanguagesCompletedEventArgs e)
        {
            this.TranslationsComplete.Clear();
            foreach (var translation in this.Translations)
            {
                foreach (var language in e.Result)
                {
                    if (translation.LanguageId == language.LanguageId)
                    {
                        this.TranslationsComplete.Add(new CompleteTranslation() { Translation = translation, Language = language });
                        break;
                    }
                }
            }
        }

        public void LoadTranslations(CompletePhrase completePhrase)
        {
            _lastPhraseSelected = completePhrase;
            _translationClient.DisplayTranslationsByPhraseIdAsync(completePhrase.Phrase.phraseId);
        }

        #region Phrases
        #region Add Phrase
        public DelegateCommand CreatePhraseCommand { get; private set; }
        void AddPhrase_Execute(object parameters)
        {
            CompletePhrase temporalPhrase = new CompletePhrase(new PhraseReference.Phrase(), new TranslationReference.Translation());
            temporalPhrase.Translation.PhraseByDefault = true;
            EditorViewModel editorViewModel = new EditorViewModel(temporalPhrase);
            EditorWindow dialog = new EditorWindow(editorViewModel);
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        PhraseReference.Phrase result = editorViewModel.PhraseResult;
                        _temporalPhraseTranslation = editorViewModel.TranslationResult;
                        _phraseClient.CreatePhraseAsync(result);
                    }
                });
        }

        bool AddPhrase_CanExecute(object parameters)
        {
            return true;
        }

        private void CreatePhraseComplete(object sender, PhraseReference.CreatePhraseCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (e.Result > 0)
            {
                _temporalPhraseTranslation.PhraseId = e.Result;
                _translationClient.CreateTranslationAsync(_temporalPhraseTranslation);
            }
            else
            {
                informationViewModel.Message = "The item was not created, please try again";
                _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            }
            _phraseClient.DisplayPhrasesAsync();
        }

        private void CreateTranslationComplete(object sender, TranslationReference.CreateTranslationCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (e.Result)
                informationViewModel.Message = "The item was created succesful";
            else
                informationViewModel.Message = "The item was not created, please try again";

            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            if (_lastPhraseSelected != null)
                _translationClient.DisplayTranslationsByPhraseIdAsync(_lastPhraseSelected.Phrase.phraseId);
            _phraseClient.DisplayPhrasesAsync();
        }
        #endregion

        #region Edit Phrase
        public DelegateCommand EditPhraseCommand { get; private set; }
        void EditPhrase_Execute(object parameters)
        {
            if (parameters == null)
                return;
            CompletePhrase temporalPhrase = (parameters as CompletePhrase);
            EditorViewModel editorViewModel = new EditorViewModel(temporalPhrase);
            EditorWindow dialog = new EditorWindow(editorViewModel);
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        PhraseReference.Phrase result = editorViewModel.PhraseResult;
                        _temporalPhraseTranslation = editorViewModel.TranslationResult;
                        _phraseClient.EditPhraseAsync(result);
                    }
                });
        }

        bool EditPhrase_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void EditPhraseComplete(object sender, PhraseReference.EditPhraseCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (e.Result)
                _translationClient.EditTranslationAsync(_temporalPhraseTranslation);
            else
            {
                informationViewModel.Message = "The item was not edited, please try again";
                _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            }
            _phraseClient.DisplayPhrasesAsync();
        }

        private void EditTranslationComplete(object sender, TranslationReference.EditTranslationCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (e.Result)
                informationViewModel.Message = "The item was edited succesful.";
            else
                informationViewModel.Message = "The item was not edited, please try again";

            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _phraseClient.DisplayPhrasesAsync();
            _translationClient.DisplayTranslationsByPhraseIdAsync(_lastPhraseSelected.Phrase.phraseId);
        }
        #endregion

        #region Delete Phrase
        public DelegateCommand DeletePhraseCommand { get; private set; }
        void DeletePhrase_Execute(object parameters)
        {
            if (parameters == null)
                return;
            CompletePhrase temporalPhrase = (parameters as CompletePhrase);
            var result = _messageBoxService.Show(string.Format("Are you sure you want to delete phrase {0} ?", temporalPhrase.Translation.TranslationContent),
                "Delete Language",
                GenericMessageBoxButton.OkCancel);

            if (result == GenericMessageBoxResult.Ok)
                _phraseClient.DeletePhraseAsync(temporalPhrase.Phrase.phraseId);
        }

        bool DeletePhrase_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void DeletePhraseComplete(object sender, PhraseReference.DeletePhraseCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was deleted succesful";
            else
                informationViewModel.Message = "The item was not deleted, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            this.TranslationsComplete.Clear();
            _phraseClient.DisplayPhrasesAsync();
        }
        #endregion
        #endregion

        #region Translations

        #region Add Translation
        public DelegateCommand CreateTranslationCommand { get; private set; }
        void AddTranslation_Execute(object parameters)
        {
            if (parameters == null)
                return;
            CompletePhrase temporalPhrase = (parameters as CompletePhrase);
            TranslationEditorViewModel editorViewModel = new TranslationEditorViewModel(temporalPhrase.Phrase, new TranslationReference.Translation());
            TranslationEditorWindow dialog = new TranslationEditorWindow(editorViewModel);
            _translationModalDialogService.ShowDialog<TranslationEditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        TranslationReference.Translation result = editorViewModel.TranslationResult;
                        _temporalPhraseTranslation = editorViewModel.TranslationResult;
                        _translationClient.CreateTranslationAsync(result);
                    }
                });
        }

        bool AddTranslation_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }
        #endregion

        #region Edit Translation
        public DelegateCommand EditTranslationCommand { get; private set; }
        void EditTranslation_Execute(object parameters)
        {
            if (parameters == null)
                return;
            CompleteTranslation temporalTranslation = (parameters as CompleteTranslation);
            foreach (var item in this.Phrases2)
            {
                if (item.Phrase.phraseId == temporalTranslation.Translation.PhraseId)
                {
                    TranslationEditorViewModel editorViewModel = new TranslationEditorViewModel(item.Phrase, temporalTranslation.Translation);
                    TranslationEditorWindow dialog = new TranslationEditorWindow(editorViewModel);
                    _translationModalDialogService.ShowDialog<TranslationEditorViewModel>(dialog,
                        editorViewModel,
                        returnedViewModelInstance =>
                        {
                            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                            {
                                TranslationReference.Translation result = editorViewModel.TranslationResult;
                                _temporalPhraseTranslation = editorViewModel.TranslationResult;
                                _translationClient.EditTranslationAsync(result);
                            }
                        });
                    break;
                }
            }
        }

        bool EditTranslation_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        #endregion

        #region Delete Translation
        public DelegateCommand DeleteTranslationCommand { get; private set; }
        void DeleteTranslation_Execute(object parameters)
        {
            if (parameters == null)
                return;
            CompleteTranslation temporalTranslation = (parameters as CompleteTranslation);
            var result = _messageBoxService.Show(string.Format("Are you sure you want to delete phrase {0} ?", temporalTranslation.Translation.TranslationContent),
                "Delete Language",
                GenericMessageBoxButton.OkCancel);

            if (result == GenericMessageBoxResult.Ok)
                _translationClient.DeleteTranslationAsync(temporalTranslation.Translation.TranslationId);
        }

        bool DeleteTranslation_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void DeleteTranslationComplete(object sender, TranslationReference.DeleteTranslationCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was deleted succesful";
            else
                informationViewModel.Message = "The item was not deleted, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            this.TranslationsComplete.Clear();
            _phraseClient.DisplayPhrasesAsync();
        }
        #endregion

        #endregion
    }
}
