using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Uri;

namespace NBMFS.Models
{
    class EmailMessage : Message 
    {
        public string Subject { get; set; }

        public List<string> Links { get; private set; }

        [JsonConstructor]
        public EmailMessage(string id, string sender, string subject, string body)
            : base(id, sender, body, 1028, MessageType.EMAIL)
        {
            Subject = subject;

        }

        public EmailMessage(string id, string sender, string body)
            : base(id, sender, body, 1028, MessageType.EMAIL)
        {
            GetSubject();
            Links = new List<string>();
            QuarantineURL();
            if(!IsValidSubject())
                throw new Exception($"Invalid Subject: {Subject}");
        }


        private void GetSubject()
        {
            int charindex = Body.IndexOf('.');
            Subject = Body.Substring(0, charindex);
            Body = Body.Substring(charindex + 1, Body.Length - charindex - 1);
        }

        public override bool IsValidSender()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Sender);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"ID: {ID}\nSender: {Sender}\nSubject: {Subject}\nBody: {Body}\nType: {Type}\n";
        }


        public bool IsValidSubject()
        {
            if(Subject.Count() <= 20)
                return true;
            else
                return false;
        }


        public void QuarantineURL()
        {
            string[] words = Body.Split(' ');
            Body = string.Empty;
            RegexValid re = new RegexValid();
            for(int i = 0; i < words.Length; i++)
            {
                if(re.MatchURL(words[i]) == "<URL Quarantined>")
                    Links.Add(words[i]);

                words[i] = re.MatchURL(words[i]);

                if(words[i] != "")
                    Body += words[i] + " ";
            }
        }

        public override string ToFormBody()
        {
            return $"{Sender} {Subject}. {Body}";
        }

    }
}
