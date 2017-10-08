using Rabbit.Contract;
using Rabbit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Service
{
    public class InternalService : IGateway
    {
        public AlertResponse Alert(AlertRequest request)
        {
            return new AlertResponse();
        }

        public LocationResponse LocationUpdate(LocationRequest request)
        {
            return new LocationResponse();
        }
    }
}
