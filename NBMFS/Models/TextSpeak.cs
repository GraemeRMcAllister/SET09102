using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    public class TextSpeak
    {
        public string Abbreviation { get; set; }
        public string Word { get; set; }

        public TextSpeak()
        {

        }

        public TextSpeak(string abbr, string word)
        {
            Abbreviation = abbr;
            Word = word;
        }
    }
}
