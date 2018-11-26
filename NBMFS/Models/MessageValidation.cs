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
            if ((header.Length == 10) && (int.TryParse(header.Substring(1, 9), out int res))) // True if header is 10 and the ID is a number
            {
                foreach (Enum s in Enum.GetValues(typeof(MessageType))) // gets the preset type list in Message CLass
                {
                    typelist += $" {s},";                                       // building the message box if function fails
                    if (s.ToString().Substring(0, 1) == header.Substring(0, 1)) // compares the first char(string) in header, to the first char(string) in type
                        return;
                }
                throw new Exception($"Header start must correspond to one of{typelist.TrimEnd(',')}."); // returning list of types
            }
            throw new Exception("Header must be a Message-type indicator; followed by a 9 digit ID."); // if header is 10 and the ID is a number is false
        }
    }
}
