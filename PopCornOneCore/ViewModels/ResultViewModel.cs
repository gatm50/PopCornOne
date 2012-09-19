using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;

namespace PopCornOneCoreWindowsPhone.ViewModels
{
    public class ResultViewModel : MvxViewModel
    {
        private TranslationReference.TranslationServiceClient _translationClient;
        public ObservableCollection<TranslationReference.Translation> PhraseResults;

        public ResultViewModel(string lexicon)
        {
            _translationClient = new TranslationReference.TranslationServiceClient();
            _translationClient.DisplayTranslationByLexiconCompleted += this.DisplayTranslationByLexiconComplete;
            this.PhraseResults = new ObservableCollection<TranslationReference.Translation>();

            _translationClient.DisplayTranslationByLexiconAsync(lexicon);
        }

        private void DisplayTranslationByLexiconComplete(object sender, TranslationReference.DisplayTranslationByLexiconCompletedEventArgs e)
        {
            this.PhraseResults.Clear();

            foreach (var item in e.Result)
                this.PhraseResults.Add(item);
        }
    }
}
