using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class RegexValid
    {
        string URLPatternREG = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$" ;
        string SortCodeREG = @"\b[0-9]{2}-?[0-9]{2}-?[0-9]{2}\b";

        public string MatchURL(string str)
        {
            bool period = false;
            if (str.EndsWith("."))
            {
                str = str.Remove(str.Length - 1);
                period = true;
            }

            if (Regex.IsMatch(str, URLPatternREG))
                    str = "<URL Quarantined>";

            if (period)
                return str + ".";
            else
                return str;
        }

        public bool MatchSortCode(string str)
        {
            if (Regex.IsMatch(str, SortCodeREG))
                return true;
            else
                return false;
        }

    }

}
