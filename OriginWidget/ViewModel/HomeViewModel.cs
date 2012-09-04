using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LanguageWidget.Utils;
using Utils;
using Utils.MessageBox;
using Utils.ModalDialog;

namespace OriginWidget.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private OriginReference.OriginServiceClient _originClient;
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
                _originClient.DisplayOriginsAsync();
            }
        }
        public int CurrentLanguageId { get; set; }
        public ObservableCollection<OriginReference.Origin> Origins { get; set; }

        private readonly IMessageBoxService _messageBoxService;
        private readonly IModalDialogService _modalDialogService;
        private readonly IModalDialogService _informationDialogService;

        public HomeViewModel()
        {
            this.Origins = new ObservableCollection<OriginReference.Origin>() { };
            this.CurrentLanguageId = -1;

            this.CreateOriginCommand = new DelegateCommand(AddContact_Execute, AddContact_CanExecute);
            this.EditOriginCommand = new DelegateCommand(EditContact_Execute, EditContact_CanExecute);
            this.DeleteOriginCommand = new DelegateCommand(DeleteContact_Execute, DeleteContact_CanExecute);

            _originClient = new OriginReference.OriginServiceClient();
            _originClient.CreateOriginCompleted += CreateLanguageComplete;
            _originClient.DisplayOriginsCompleted += DisplayListLanguageComplete;
            _originClient.EditOriginCompleted += EditLanguageComplete;
            _originClient.DeleteOriginCompleted += DeleteLanguageComplete;

            _originClient.DisplayOriginsAsync();

            _messageBoxService = new MessageBoxService();
            _modalDialogService = new ModalDialogService();
            _informationDialogService = new ModalDialogService();
        }

        private void DisplayListLanguageComplete(object sender, OriginReference.DisplayOriginsCompletedEventArgs e)
        {
            this.Origins.Clear();
            if (_searchTerm == null)
                _searchTerm = string.Empty;
            foreach (var item in e.Result)
            {
                if (_searchTerm == string.Empty)
                    this.Origins.Add(item);
                else
                {
                    string temporalLanguageNameLower = item.OriginName.ToLower();
                    string temporalSearchTermLower = _searchTerm.ToLower();
                    if (temporalLanguageNameLower.Contains(temporalSearchTermLower))
                        this.Origins.Add(item);
                }

            }

        }

        #region Add Language
        public DelegateCommand CreateOriginCommand { get; private set; }
        void AddContact_Execute(object parameters)
        {
            OriginReference.Origin temporalLanguage = new OriginReference.Origin { OriginId = 0, OriginName = "", OriginUrl = "" };
            EditorWindow dialog = new EditorWindow();
            EditorViewModel editorViewModel = new EditorViewModel(temporalLanguage);
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        OriginReference.Origin result = editorViewModel.ObjectResult;
                        _originClient.CreateOriginAsync(result);
                    }
                });
        }

        bool AddContact_CanExecute(object parameters)
        {
            return true;
        }

        private void CreateLanguageComplete(object sender, OriginReference.CreateOriginCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was created succesful";
            else
                informationViewModel.Message = "The item was not created, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _originClient.DisplayOriginsAsync();
        }
        #endregion

        #region Edit Origin
        public DelegateCommand EditOriginCommand { get; private set; }
        void EditContact_Execute(object parameters)
        {
            if (parameters == null)
                return;
            EditorWindow dialog = new EditorWindow();
            EditorViewModel editorViewModel = new EditorViewModel((parameters as OriginReference.Origin));
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        OriginReference.Origin result = editorViewModel.ObjectResult;
                        _originClient.EditOriginAsync(result);
                    }
                });
        }

        bool EditContact_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void EditLanguageComplete(object sender, OriginReference.EditOriginCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was edited succesful";
            else
                informationViewModel.Message = "The item was not edited, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _originClient.DisplayOriginsAsync();
        }
        #endregion

        #region Delete Origin
        public DelegateCommand DeleteOriginCommand { get; private set; }
        void DeleteContact_Execute(object parameters)
        {
            OriginReference.Origin temporalOrigin = (parameters as OriginReference.Origin);
            var result = _messageBoxService.Show(string.Format("Are you sure you want to delete origin {0} ?", temporalOrigin.OriginName),
                "Delete Origin",
                GenericMessageBoxButton.OkCancel);

            if (result == GenericMessageBoxResult.Ok)
                _originClient.DeleteOriginAsync(temporalOrigin.OriginId);
        }

        bool DeleteContact_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void DeleteLanguageComplete(object sender, OriginReference.DeleteOriginCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was deleted succesful";
            else
                informationViewModel.Message = "The item was not deleted, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _originClient.DisplayOriginsAsync();
        }
        #endregion
    }
}
