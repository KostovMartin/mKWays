using System;
using Mk.AJAX;
using Newtonsoft.Json;

namespace MkAjax.Demo.webapi
{
    public class MkJson : IMkJson
    {
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }
    }
}