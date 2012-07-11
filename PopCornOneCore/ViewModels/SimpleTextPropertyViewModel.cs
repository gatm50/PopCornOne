using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;

namespace PopCornOneCoreWindowsPhone.ViewModels
{
    public class SimpleTextPropertyViewModel
        : MvxViewModel
    {
        private string _theText;
        public string TheText
        {
            get { return _theText; }
            set 
            {
                _theText = value; 
                FirePropertyChanged(() => TheText); 
            }
        }

        public SimpleTextPropertyViewModel()
        {
            TheText = "XD";
        }
    }
}