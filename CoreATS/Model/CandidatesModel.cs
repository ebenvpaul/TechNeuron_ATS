using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreATS.Model
{
    [DataContract]
    public class CandidatesModel
    {

        
        [DataMember(Name = "CandidateGuid")]
        public string CandidateGuid { get; set; }

        [DataMember(Name = "CandidateId")]
        public int CandidateId { get; set; }
      

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Age")]
        public int Age { get; set; }

        [DataMember(Name = "DOB")]
        public DateTime DOB { get; set; }


        [DataMember(Name = "Qualification")]
        public string Qualification { get; set; }


        [DataMember(Name = "AppliedJobId")]
        public int AppliedJobId { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }

      
        [DataMember(Name = "StatusId")]
        public int StatusId { get; set; }
        
        [DataMember(Name = "MobileNo")]
        public string MobileNo { get; set; }

        [DataMember(Name = "EmailId")]
        public string EmailId { get; set; }


        [DataMember(Name = "CandidateDetailGuid")]
        public string CandidateDetailGuid { get; set; }


        [DataMember(Name = "SkillId")]
        public int SkillId { get; set; }


        [DataMember(Name = "RankingId")]
        public int RankingId { get; set; }

        [DataMember(Name = "RankingScore")]
        public int RankingScore { get; set; }

        [DataMember(Name = "CVFileLocation")]
        public string CVFileLocation { get; set; }

        
      
    }
}
