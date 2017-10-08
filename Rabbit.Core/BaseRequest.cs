using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Core
{
    [DataContract]
    [ProtoContract]
    [ProtoInclude(10, typeof(AlertRequest))]
    [ProtoInclude(11, typeof(LocationRequest))]
    public abstract class BaseRequest
    {
        public abstract MessageType MessageType { get; }
    }
}
