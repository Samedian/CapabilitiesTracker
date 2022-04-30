using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    
    class Capability
    {
        private static int count = 1;
        public Capability(List<string> Ko,ArrayList NonKo,string Summary,Track MyTrack)
        {
            this.CapabilityId = "CID"+count++ ;
            this.Ko = Ko;
            this.NonKo = NonKo;
            this.Summary = Summary;
            this.MyTrack = MyTrack;
        }
        public string CapabilityId { get; set; }

        public List<string> Ko { get; set; }

        public string Summary { get; set; }

        public ArrayList NonKo { get; set; }

        public Track MyTrack { get; set; }
    }
}
