using System.Collections.Generic;
using System.ServiceModel;
using PopCornOneWebApp.Models;

namespace PopCornOneWebApp.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAutorService" in both code and config file together.
    [ServiceContract]
    public interface IAutorService
    {
        [OperationContract]
        List<Autor> DisplayAutors();

        [OperationContract]
        bool CreateAutor(Autor autor);

        [OperationContract]
        bool EditAutor(Autor autor);

        [OperationContract]
        bool DeleteAutor(int id);
    }
}
