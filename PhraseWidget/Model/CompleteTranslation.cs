using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PhraseWidget.Model
{
    public class CompleteTranslation
    {
        public TranslationReference.Translation Translation { get; set; }
        public LanguageReference.Language Language { get; set; }
    }
}
