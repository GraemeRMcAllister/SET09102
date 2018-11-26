using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    abstract class TextSpeakMessage : Message
    {

        public TextSpeakMessage(string id, string sender, string body, int maxsize, MessageType t)
            : base(id, sender, body, maxsize, t)
        {

        }

        internal string  ConvertTextspeak()
        {
            string[] words = Body.Split(' ');
            string newbody = string.Empty;
            string word = string.Empty;
            bool period = false;
            ReadCSV read = new ReadCSV();
            read.ReadTextSpeak();
            for (int i = 0; i < words.Length; i++)
            {
                period = false;
                foreach (TextSpeak ts in read.Translate)
                {
                    if (words[i].EndsWith("."))
                    {
                        word = words[i].TrimEnd('.');
                        period = true;
                    }
                    else
                        word = words[i];

                    if (word == ts.Abbreviation)
                    {
                        words[i] = word + $"<{ts.Word}>";
                        if (period)
                            words[i] += ".";
                        break;
                    }
                }
                newbody += words[i] + " ";
            }

            return newbody;
        }

    }

}
