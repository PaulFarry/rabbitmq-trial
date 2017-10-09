using System.IO;

namespace Rabbit.Core
{
    public class Utility
    {
        public static byte[] Serialise(BaseRequest request)
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, request);
                return ms.ToArray();
            }
        }
        public static BaseRequest DeSerialise(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return ProtoBuf.Serializer.Deserialize<BaseRequest>(ms);
            }
        }
    }
}
