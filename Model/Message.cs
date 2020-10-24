using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TechNeuron_ATS.Model
{
   
    public class Message<T>
    {
      
        public bool IsSuccess { get; set; }

        public string ReturnMessage { get; set; }

        
        public T Data { get; set; }
    }
}
