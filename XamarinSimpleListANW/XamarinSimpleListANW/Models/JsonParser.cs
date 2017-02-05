using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinSimpleListANW.Models
{
    public static class JsonParser
    {
        public static object ParseJson(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }
    }
}
