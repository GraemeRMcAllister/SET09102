using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NBMFS.Models
{
    class ReadCSV
    {
        public List<TextSpeak> Translate { get; private set; }
        public List<Incidents> Incidents { get; private set; }

        public ReadCSV()
        {
            Incidents = new List<Incidents>();
            Translate = new List<TextSpeak>();
        }

        public void ReadTextSpeak()
        {
            using (StreamReader reading = new StreamReader("textwords.csv"))
            {
                while (!reading.EndOfStream)
                {
                    var line = reading.ReadLine();
                    var values = line.Split(',');
                    Translate.Add(new TextSpeak(values[0], values[1]));
                }
            }
        }

        public void ReadIncidentList()
        {
            using (StreamReader reading = new StreamReader("incidents.csv"))
            {
                while (!reading.EndOfStream)
                {
                    var line = reading.ReadLine();
                    var value = line.Split(',');
                    Incidents.Add(new Incidents(value[0]));
                }
            }
        }
    }

}
