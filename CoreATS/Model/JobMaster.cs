using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreATS.Model
{
    [DataContract]
    public class JobMaster
    {
               
        [DataMember(Name = "JobId")]
        public int JobId { get; set; }
             
        [DataMember(Name = "JobTitle")]
        public string JobTitle { get; set; }

        [DataMember(Name = "JobDescription")]
        public string JobDescription { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

             
            }
}
