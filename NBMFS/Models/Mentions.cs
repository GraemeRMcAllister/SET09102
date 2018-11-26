using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class Mentions
    {
        public int Counter { get; set; }
        public string Handle { get; set; }

        /*public Mentions()
        {
            Counter = 1;
        }
        */
        public Mentions(string handle)
        {
            Handle = handle;
            Counter = 1;
        }
    }
}
