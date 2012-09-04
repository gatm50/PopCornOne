using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;


namespace PopCornOneCoreWindowsPhone.ViewModels
{
    //public class MainMenuViewModel : MvxViewModel 
    //{
    //    private string _searchText;
    //    public string SearchText
    //    {
    //        get
    //        {
    //            return _searchText;
    //        }
    //        set
    //        {
    //            _searchText = value;
    //            FirePropertyChanged(() => this.SearchText);
    //        }
    //    }
    //    public List<Type> Items { get; set; }
    //    public ObservableCollection<string> ListValues { get; set; }

    //    public IMvxCommand ShowItemCommand
    //    {
    //        get
    //        {
    //            return new MvxRelayCommand(DoSomething_Execute);
    //            //return new MvxRelayCommand<Type>((type) => this.RequestNavigate(type));
    //        }
    //    }

    //    public void DoSomething_Execute()
    //    {
    //        ListValues.Add("A Val");
    //    }
    //    public MainMenuViewModel()
    //    {
    //        SearchText = "XD";
    //        Items = new List<Type>() 
    //        {
    //            typeof(SimpleTextPropertyViewModel)
    //        };

    //        ListValues = new ObservableCollection<string>()
    //        {
    //            "Value 1",
    //            "Value 1",
    //            "Value 1"
    //        };
    //    }
    //}
}
