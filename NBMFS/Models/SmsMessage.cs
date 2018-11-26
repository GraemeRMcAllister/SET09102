using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class SmsMessage : TextSpeakMessage
    {

        public SmsMessage(string id, string sender, string body)
            : base(id, sender, body, 140, MessageType.SMS)
        {
        }

        public override string ToString()
        {
            return $"ID: {ID}\nSender: {Sender}\nBody: {ConvertTextspeak()}\nType: {Type}";
        }

        public override string ToFormBody()
        {
            return $"{Sender} {ConvertTextspeak()}";
        }

        public override bool IsValidSender()
        {
            if (!Sender.StartsWith("+"))
                return false;


            if (Sender.Length > 15)
                return false;

            try { Convert.ToInt64(Sender.TrimStart('+')); }
            catch { return false; }

            return true;
        }
        
    }
}
