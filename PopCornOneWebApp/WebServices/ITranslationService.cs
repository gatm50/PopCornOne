using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PopCornOneWebApp.Models;

namespace PopCornOneWebApp.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITranslationService" in both code and config file together.
    [ServiceContract]
    public interface ITranslationService
    {
        [OperationContract]
        List<Translation> DisplayTranslations();

        [OperationContract]
        List<Translation> DisplayTranslationsByPhraseId(int phraseId);

        [OperationContract]
        List<Translation> DisplayTranslationByLexicon(string lexicon, int languageId);

        [OperationContract]
        List<Translation> DisplayTranslationByFirstLetter(string character, int languageId);

        [OperationContract]
        List<Translation> DisplayTranslationByLanguage( int languageId);

        [OperationContract]
        bool CreateTranslation(Translation translation);

        [OperationContract]
        bool EditTranslation(Translation translation);

        [OperationContract]
        bool DeleteTranslation(int id);
    }
}
