using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBMFS.Models
{
    class Incidents
    {
        public string Incident { get; set; }

        public Incidents()
        {

        }
        public Incidents(string incident)
        {
            Incident = incident;
        }
    }
}
