
namespace PhraseWidget.Model
{
    public class CompletePhrase
    {
        public CompletePhrase(PhraseReference.Phrase phrase, TranslationReference.Translation translation)
        {
            this.Phrase = phrase;
            this.Translation = translation;
        }

        public PhraseReference.Phrase Phrase { get; set; }
        public TranslationReference.Translation Translation { get; set; }
    }
}
