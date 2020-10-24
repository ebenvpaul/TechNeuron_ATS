using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TechNeuron_ATS.Model
{
  
    public class SkillSets
    {
        
     
        public int SkillId { get; set; }
             
       
        public int JobId { get; set; }

       
        public string SkillTitle { get; set; }

       
        public string SkillDesc { get; set; }

      
        public bool IsActive { get; set; }

       
        public bool IsMandatory { get; set; }

       
        public DateTime CreatedDate { get; set; }

       
        public int RankingId { get; set; }
    }
}
