using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BsonData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Bson;
namespace Vst
{
    
    public class Bson
    {
        public static void Write(FileStream stream, object value)
        {
            using (var bw = new Newtonsoft.Json.Bson.BsonWriter(stream))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(bw, value);
            }
        }
        public static JObject Read(FileStream stream)
        {
            using (var br = new Newtonsoft.Json.Bson.BsonReader(stream))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                return (JObject)serializer.Deserialize(br);
            }
        }
        public static T Read<T>(FileStream stream)
        {
            var o = Read(stream);
            return o.ToObject<T>();
        }
    }
}
