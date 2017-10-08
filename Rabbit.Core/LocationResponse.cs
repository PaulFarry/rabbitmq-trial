using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Core
{
    [DataContract]
    public class LocationResponse
    {
        [DataMember]
        public int Id { get; set; }
    }
}
