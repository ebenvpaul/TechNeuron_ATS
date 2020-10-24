using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TechNeuron_ATS.Model
{
       public class CandidatesModel
    {

        
      
        public string CandidateGuid { get; set; }

       
        public int CandidateId { get; set; }
      

       
        public string Name { get; set; }

        
        public int Age { get; set; }

       
        public DateTime DOB { get; set; }


        
        public string Qualification { get; set; }


        
        public int AppliedJobId { get; set; }

       
        public DateTime CreatedDate { get; set; }

        
        public bool IsActive { get; set; }

      
       
        public int StatusId { get; set; }
        
        
        public string MobileNo { get; set; }

       
        public string EmailId { get; set; }


        
        public string CandidateDetailGuid { get; set; }


        
        public int SkillId { get; set; }


       
        public int RankingId { get; set; }

       
        public int RankingScore { get; set; }

        
        public string CVFileLocation { get; set; }

        
      
    }
}
