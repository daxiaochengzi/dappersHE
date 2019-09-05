using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace DapperTast.Helper
{
    public class XmlHelper
    {
        public static string ToXml<T>(T t)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          
            string json =  JsonConvert.SerializeObject(t, settings);
       
            string xml = JsonConvert.DeserializeXNode(json, "Response", true).ToString();
            return xml;
        }
    }
}
