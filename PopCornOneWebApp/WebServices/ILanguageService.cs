using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PopCornOneWebApp.Models;

namespace PopCornOneWebApp.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILanguageService" in both code and config file together.
    [ServiceContract]
    public interface ILanguageService
    {
        [OperationContract]
        List<Language> DisplayLanguages();

        [OperationContract]
        bool CreateLanguage(Language language);

        [OperationContract]
        bool EditLanguage(Language language);

        [OperationContract]
        bool DeleteLanguage(int id);
    }
}
