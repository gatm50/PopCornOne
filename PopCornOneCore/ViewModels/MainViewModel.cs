using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using Cirrious.MvvmCross.Interfaces.Commands;
using System;
using Cirrious.MvvmCross.Commands;

namespace PopCornOneCoreWindowsPhone.ViewModels
{
    public class MainViewModel : MvxViewModel 
    {
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                FirePropertyChanged(() => Search);
            }
        }
        public List<Type> Items { get; set; }

        public IMvxCommand ShowItemCommand
        {
            get
            {
                return new MvxRelayCommand<Type>((type) => this.RequestNavigate(type));
            }
        }

        public MainViewModel()
        {
            this.Search = string.Empty;
            Items = new List<Type>()
                        {
                            typeof(ViewModels.MainViewModel)
                        };
        }
    }
}
