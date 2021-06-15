using System.Collections.Generic;
using Newtonsoft.Json;

namespace patronage21_qa_appium.Models
{
    internal class TechGroupsResponse
    {
        [JsonProperty("groups")]
        public List<string> groups { get; set; }
    }
}