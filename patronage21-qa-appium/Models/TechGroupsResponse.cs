using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace patronage21_qa_appium.Models
{
    class TechGroupsResponse
    {
        [JsonProperty("groups")]
        public List<string> groups { get; set; }
    }
}
