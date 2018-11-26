using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class Hashtags
    {
        public int Counter { get; set; }
        public string Hashtag { get; set; }

        /*public Hashtags()
        {
            //Counter = 1;
        }
        */
        public Hashtags(string hashtag)
        {
            Hashtag = hashtag;
            Counter = 1;
        }

    }
}
