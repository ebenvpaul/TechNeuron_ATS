using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreATS.Model
{
    [DataContract]
    public class SkillSet
    {
        
        [DataMember(Name = "SkillId")]
        public int SkillId { get; set; }
             
        [DataMember(Name = "JobId")]
        public int JobId { get; set; }

        [DataMember(Name = "SkillTitle")]
        public string SkillTitle { get; set; }

        [DataMember(Name = "SkillDesc")]
        public string SkillDesc { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }

        [DataMember(Name = "IsMandatory")]
        public bool IsMandatory { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "RankingId")]
        public int RankingId { get; set; }
    }
}
