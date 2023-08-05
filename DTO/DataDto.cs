using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIAutomation.DTO
{
    public class DataDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("CPU model")]
        public string CpuModel { get; set; }

        [JsonProperty("Hard disk size")]
        public string HardDiskSize { get; set; }
    }
}

