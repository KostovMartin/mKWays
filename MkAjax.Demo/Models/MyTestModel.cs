using System.Collections.Generic;
using Mk.AJAX;
using Newtonsoft.Json;

namespace MkAjax.Demo.Models
{
    [JsonModel]
    public class MyTestModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> Items { get; set; }
        private string Description { get; set; }
        [JsonIgnore]
        public string AdditionalDescription { get; set; }
    }
}