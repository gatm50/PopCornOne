using System.Collections.Generic;
using System.ServiceModel;
using PopCornOneWebApp.Models;

namespace PopCornOneWebApp.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOriginService" in both code and config file together.
    [ServiceContract]
    public interface IOriginService
    {
        [OperationContract]
        List<Origin> DisplayOrigins();

        [OperationContract]
        bool CreateOrigin(Origin origin);

        [OperationContract]
        bool EditOrigin(Origin origin);

        [OperationContract]
        bool DeleteOrigin(int id);
    }
}
