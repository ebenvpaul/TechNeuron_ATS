using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TechNeuron_ATS.Model
{
    
    public class Rank
    {

      
        public int RankingId { get; set; }
             
       
        public string RankingTitle { get; set; }

        
        public string RankingDesc { get; set; }

       
        public int MinRank { get; set; }

       
        public int MaxRank { get; set; }

        
      
        public bool IsActive { get; set; }


        
        public DateTime CreatedDate { get; set; }
    }
}
