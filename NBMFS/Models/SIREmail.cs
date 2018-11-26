using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class SIREmail : EmailMessage
    {
        public string SortCode { get; set; }
        public string NOI { get; set; }

        [JsonConstructor]
        public SIREmail(string id, string sender, string subject, string noi, string sortcode, string body)
    : base(id, sender, subject, body)
        {
            NOI = noi;
            SortCode = sortcode;

        }

        public SIREmail(string id, string sender, string body)
            : base(id, sender, body)
        {
            Type = MessageType.SIR;

            GetSortCodeandNOI();

            if (!DateTime.TryParse(Subject.Split(' ')[1], out var dateasd))
                throw new Exception($"{Type}: Invalid Date:{Subject.Split(' ')[1]}");

            if (!ParseIncident())
                throw new Exception($"{Type}: Invalid Nature of Incident:{NOI}");

            if (!ValidateSortCode())
                throw new Exception($"{Type}: Invalid Sort Code:{SortCode}");
        }

        private void GetSortCodeandNOI()
        {
            int sb = 0;
            string[] SIRBody = Body.Split(' ');
            if (SIRBody[0] == "")
                sb = 1;
            SortCode = SIRBody[sb];
            NOI = SIRBody[sb + 1];
            string SIRdate = string.Empty;

            for (int x = sb + 2; x < SIRBody.Length; x++)
            {
                Body += $"{SIRBody[x]} ";
            }
        }


        public bool ParseIncident()
        {
            ReadCSV read = new ReadCSV();
            read.ReadIncidentList();

            foreach (Incidents i in read.Incidents)
            {
                if (NOI == i.Incident)
                {
                    return true;
                }
            }

            return false;

        }

        public bool ValidateSortCode()
        {
            RegexValid re = new RegexValid();
            return re.MatchSortCode(SortCode);
        }

        public override string ToFormBody()
        {
            return $"{Sender} {Subject}. {SortCode} {NOI} {Body}";
        }

        public override string ToString()
        {
            return $"ID: {ID}\nSender: {Sender}\nSubject: {Subject}\nBody: {SortCode} {NOI} {Body}\nType: {Type}\n";
        }
    }
}
