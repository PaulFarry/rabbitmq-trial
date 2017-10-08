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
    public class LocationRequest : BaseRequest
    {
        [ProtoMember(1)]
        [DataMember]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public Decimal Latitude { get; set; }

        [ProtoMember(3)]
        [DataMember]
        public decimal Longitude { get; set; }

        public override MessageType MessageType =>  MessageType.Location;
    }
}
