using Newtonsoft.Json;
using RestAPIAutomation.Common;

namespace RestAPIAutomation.DTO
{
    public class CtreateObjectDto
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
