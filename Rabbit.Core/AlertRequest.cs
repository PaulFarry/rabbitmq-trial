using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Core
{
    [ProtoContract]
    [DataContract]
    public class AlertRequest : BaseRequest
    {
        [ProtoMember(1)]
        [DataMember]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public DateTime Arrived { get; set; }

        public override MessageType MessageType => MessageType.Alert;
    }
}
