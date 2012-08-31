using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PopCornOneWebApp.Models;

namespace PopCornOneWebApp.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPhraseService" in both code and config file together.
    [ServiceContract]
    public interface IPhraseService
    {
        [OperationContract]
        List<Phrase> DisplayPhrases();

        [OperationContract]
        int CreatePhrase(Phrase phrase);

        [OperationContract]
        bool EditPhrase(Phrase phrase);

        [OperationContract]
        bool DeletePhrase(int id);
    }
}
