using Rabbit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Contract
{
    [ServiceContract(Name = "GatewayService",
                       Namespace = "http://paulfarry/gatewayservice")]
    public interface IGateway
    {
        [OperationContract]
        AlertResponse Alert(AlertRequest request);

        [OperationContract]
        LocationResponse LocationUpdate(LocationRequest request);

    }
}
