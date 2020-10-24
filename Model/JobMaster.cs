using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TechNeuron_ATS.Model
{

   
    public class JobMaster
    {
        [JsonProperty("JobId")]
        public int JobId { get; set; }

        [JsonProperty("JobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("JobDescription")]
        public string JobDescription { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

       
}





}
