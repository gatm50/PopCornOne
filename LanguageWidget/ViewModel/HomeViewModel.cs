using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LanguageWidget.Utils;
using LanguageWidget.Views;
using Utils;
using Utils.MessageBox;
using Utils.ModalDialog;

namespace LanguageWidget.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private LanguageReference.LanguageServiceClient _languageClient;
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
                _languageClient.DisplayLanguagesAsync();
            }
        }
        public int CurrentLanguageId { get; set; }
        public ObservableCollection<LanguageReference.Language> Languages { get; set; }

        private readonly IMessageBoxService _messageBoxService;
        private readonly IModalDialogService _modalDialogService;
        private readonly IModalDialogService _informationDialogService;

        public HomeViewModel()
        {
            this.Languages = new ObservableCollection<LanguageReference.Language>() { };
            this.CurrentLanguageId = -1;

            this.CreateLanguageCommand = new DelegateCommand(AddContact_Execute, AddContact_CanExecute);
            this.EditLanguageCommand = new DelegateCommand(EditContact_Execute, EditContact_CanExecute);
            this.DeleteLanguageCommand = new DelegateCommand(DeleteContact_Execute, DeleteContact_CanExecute);

            _languageClient = new LanguageReference.LanguageServiceClient();
            _languageClient.CreateLanguageCompleted += CreateLanguageComplete;
            _languageClient.DisplayLanguagesCompleted += DisplayListLanguageComplete;
            _languageClient.EditLanguageCompleted += EditLanguageComplete;
            _languageClient.DeleteLanguageCompleted += DeleteLanguageComplete;

            _languageClient.DisplayLanguagesAsync();

            _messageBoxService = new MessageBoxService();
            _modalDialogService = new ModalDialogService();
            _informationDialogService = new ModalDialogService();
        }

        private void SearchLanguage()
        {
            if (_searchTerm == null)
                _searchTerm = string.Empty;
            return;
        }

        private void DisplayListLanguageComplete(object sender, LanguageReference.DisplayLanguagesCompletedEventArgs e)
        {
            this.Languages.Clear();
            if (_searchTerm == null)
                _searchTerm = string.Empty;
            foreach (var item in e.Result)
            {
                if (_searchTerm == string.Empty)
                    this.Languages.Add(item);
                else
                {
                    string temporalLanguageNameLower = item.LanguageName.ToLower();
                    string temporalSearchTermLower = _searchTerm.ToLower();
                    if (temporalLanguageNameLower.Contains(temporalSearchTermLower))
                        this.Languages.Add(item);
                }

            }

        }

        #region Add Language
        public DelegateCommand CreateLanguageCommand { get; private set; }
        void AddContact_Execute(object parameters)
        {
            LanguageReference.Language temporalLanguage = new LanguageReference.Language { LanguageId = 0, LanguageName = "Insert Language Name" };
            EditorWindow dialog = new EditorWindow();
            EditorViewModel editorViewModel = new EditorViewModel(temporalLanguage);
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        LanguageReference.Language result = editorViewModel.ObjectResult;
                        _languageClient.CreateLanguageAsync(result);
                    }
                });
        }

        bool AddContact_CanExecute(object parameters)
        {
            return true;
        }

        private void CreateLanguageComplete(object sender, LanguageReference.CreateLanguageCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was created succesful";
            else
                informationViewModel.Message = "The item was not created, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _languageClient.DisplayLanguagesAsync();
        }
        #endregion

        #region Edit Language
        public DelegateCommand EditLanguageCommand { get; private set; }
        void EditContact_Execute(object parameters)
        {
            if (parameters == null)
                return;
            EditorWindow dialog = new EditorWindow();
            EditorViewModel editorViewModel = new EditorViewModel((parameters as LanguageReference.Language));
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        LanguageReference.Language result = editorViewModel.ObjectResult;
                        _languageClient.EditLanguageAsync(result);
                    }
                });
        }

        bool EditContact_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void EditLanguageComplete(object sender, LanguageReference.EditLanguageCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was edited succesful";
            else
                informationViewModel.Message = "The item was not edited, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _languageClient.DisplayLanguagesAsync();
        }
        #endregion

        #region Delete Language
        public DelegateCommand DeleteLanguageCommand { get; private set; }
        void DeleteContact_Execute(object parameters)
        {
            Debug.WriteLine("Start");
            LanguageReference.Language temporalLanguage = (parameters as LanguageReference.Language);
            var result = _messageBoxService.Show(string.Format("Are you sure you want to delete language {0} ?", temporalLanguage.LanguageName),
                "Delete Language",
                GenericMessageBoxButton.OkCancel);

            if (result == GenericMessageBoxResult.Ok)
                _languageClient.DeleteLanguageAsync(temporalLanguage.LanguageId);
        }

        bool DeleteContact_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void DeleteLanguageComplete(object sender, LanguageReference.DeleteLanguageCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was deleted succesful";
            else
                informationViewModel.Message = "The item was not deleted, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _languageClient.DisplayLanguagesAsync();
        }
        #endregion
    }
}
