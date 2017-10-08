using Rabbit.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabbit.Core;
using System.IO;

namespace Rabbit.Service
{
    public class ExternalService : IGateway
    {
        public AlertResponse Alert(AlertRequest request)
        {
            if (QueueWriterFactory.Write(QueueType.Standard, Utility.Serialise(request)))
            {
                return new AlertResponse { Id = request.Id };
            }

            throw new InvalidDataException("Couldn't do it");
        }

        public LocationResponse LocationUpdate(LocationRequest request)
        {
            if (QueueWriterFactory.Write(QueueType.Priority, Utility.Serialise(request)))
            {
                return new LocationResponse { Id = request.Id };
            }
            throw new InvalidDataException("Bad location don't do it");
        }
    }
}
