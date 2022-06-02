using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class qcreport
    {
        [JsonProperty("productionDate")]
        public DateTime productionDate { get; set; }

        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }

        [JsonProperty("moldId")]
        public string moldId { get; set; }

        [JsonProperty("machineId")]
        public string machineId { get; set; }

        [JsonProperty("batchQuantity")]
        public int batchQuantity { get; set; }

        [JsonProperty("standard")]
        public StandardDetail standard { get; set; }

        [JsonProperty("qcTester")]
        public Tester qcTester { get; set; }

        [JsonProperty("dimensionResults")]
        public ObservableCollection<DimensionResult>? dimensionResults { get; set; }

        [JsonProperty("appearanceResults")]
        public ObservableCollection<AppearanceResult>? appearanceResults { get; set; }
    }
}
