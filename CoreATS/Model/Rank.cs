using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreATS.Model
{
    [DataContract]
    public class Rank
    {

        [DataMember(Name = "RankingId")]
        public int RankingId { get; set; }
             
        [DataMember(Name = "RankingTitle")]
        public string RankingTitle { get; set; }

        [DataMember(Name = "RankingDesc")]
        public string RankingDesc { get; set; }

        [DataMember(Name = "MinRank")]
        public int MinRank { get; set; }

        [DataMember(Name = "MaxRank")]
        public int MaxRank { get; set; }

        
        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }


        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
