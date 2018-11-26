using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class MessageValidation
    {
        public static void ValidateHeader(string header)
        {
            string typelist = ";";
            if ((header.Length == 10) && (int.TryParse(header.Substring(1, 9), out int res)))
            {
                foreach (Enum s in Enum.GetValues(typeof(MessageType)))
                {
                    typelist += $" {s},";
                    if (s.ToString().Substring(0, 1) == header.Substring(0, 1))
                        return;
                }
                throw new Exception($"Header start must correspond to one of{typelist.TrimEnd(',')}.");
            }
            throw new Exception("Header must be a Message-type indicator; followed by a 9 digit ID.");
        }
    }
}
