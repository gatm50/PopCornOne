using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LanguageWidget.Utils;
using Utils;
using Utils.MessageBox;
using Utils.ModalDialog;

namespace AutorWidget.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private AutorReference.AutorServiceClient _autorClient;
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
                _autorClient.DisplayAutorsAsync();
            }
        }
        public ObservableCollection<AutorReference.Autor> Autors { get; set; }

        private readonly IMessageBoxService _messageBoxService;
        private readonly IModalDialogService _modalDialogService;
        private readonly IModalDialogService _informationDialogService;

        public HomeViewModel()
        {
            this.Autors = new ObservableCollection<AutorReference.Autor>();

            this.CreateAutorCommand = new DelegateCommand(AddAutor_Execute, AddAutor_CanExecute);
            this.EditAutorCommand = new DelegateCommand(EditAutor_Execute, EditAutor_CanExecute);
            this.DeleteAutorCommand = new DelegateCommand(DeleteAutor_Execute, DeleteAutor_CanExecute);

            _autorClient = new AutorReference.AutorServiceClient();
            _autorClient.CreateAutorCompleted += CreateAutorComplete;
            _autorClient.DisplayAutorsCompleted += DisplayListAutorComplete;
            _autorClient.EditAutorCompleted += EditAutorComplete;
            _autorClient.DeleteAutorCompleted += DeleteAutorComplete;

            _autorClient.DisplayAutorsAsync();

            _messageBoxService = new MessageBoxService();
            _modalDialogService = new ModalDialogService();
            _informationDialogService = new ModalDialogService();
        }

        private void DisplayListAutorComplete(object sender, AutorReference.DisplayAutorsCompletedEventArgs e)
        {
            this.Autors.Clear();
            if (_searchTerm == null)
                _searchTerm = string.Empty;
            foreach (var item in e.Result)
            {
                if (_searchTerm == string.Empty)
                    this.Autors.Add(item);
                else
                {
                    string temporalAutorNameLower = item.AutorName.ToLower();
                    string temporalSearchTermLower = _searchTerm.ToLower();
                    if (temporalAutorNameLower.Contains(temporalSearchTermLower))
                        this.Autors.Add(item);
                }

            }

        }

        #region Add Autor
        public DelegateCommand CreateAutorCommand { get; private set; }
        void AddAutor_Execute(object parameters)
        {
            AutorReference.Autor temporalAutor = new AutorReference.Autor { AutorId = 0, AutorName = "Insert Language Name", AutorUrl = "" };
            EditorWindow dialog = new EditorWindow();
            EditorViewModel editorViewModel = new EditorViewModel(temporalAutor);
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        AutorReference.Autor result = editorViewModel.ObjectResult;
                        _autorClient.CreateAutorAsync(result);
                    }
                });
        }

        bool AddAutor_CanExecute(object parameters)
        {
            return true;
        }

        private void CreateAutorComplete(object sender, AutorReference.CreateAutorCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was created succesful";
            else
                informationViewModel.Message = "The item was not created, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _autorClient.DisplayAutorsAsync();
        }
        #endregion

        #region Edit Autor
        public DelegateCommand EditAutorCommand { get; private set; }
        void EditAutor_Execute(object parameters)
        {
            if (parameters == null)
                return;
            EditorWindow dialog = new EditorWindow();
            EditorViewModel editorViewModel = new EditorViewModel((parameters as AutorReference.Autor));
            _modalDialogService.ShowDialog<EditorViewModel>(dialog,
                editorViewModel,
                returnedViewModelInstance =>
                {
                    if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                    {
                        AutorReference.Autor result = editorViewModel.ObjectResult;
                        _autorClient.EditAutorAsync(result);
                    }
                });
        }

        bool EditAutor_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void EditAutorComplete(object sender, AutorReference.EditAutorCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was edited succesful";
            else
                informationViewModel.Message = "The item was not edited, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _autorClient.DisplayAutorsAsync();
        }
        #endregion

        #region Delete Language
        public DelegateCommand DeleteAutorCommand { get; private set; }
        void DeleteAutor_Execute(object parameters)
        {
            Debug.WriteLine("Start");
            AutorReference.Autor temporalAutor = (parameters as AutorReference.Autor);
            var result = _messageBoxService.Show(string.Format("Are you sure you want to delete autor {0} ?", temporalAutor.AutorName),
                "Delete Autor",
                GenericMessageBoxButton.OkCancel);

            if (result == GenericMessageBoxResult.Ok)
                _autorClient.DeleteAutorAsync(temporalAutor.AutorId);
        }

        bool DeleteAutor_CanExecute(object parameters)
        {
            if (parameters == null)
                return false;
            return true;
        }

        private void DeleteAutorComplete(object sender, AutorReference.DeleteAutorCompletedEventArgs e)
        {
            InformationViewModel informationViewModel = new InformationViewModel();
            if (Convert.ToBoolean(e.Result.ToString()))
                informationViewModel.Message = "The item was deleted succesful";
            else
                informationViewModel.Message = "The item was not deleted, please try again";
            _informationDialogService.ShowDialog<InformationViewModel>(new InformationWindow(), informationViewModel);
            _autorClient.DisplayAutorsAsync();
        }
        #endregion
    }
}
