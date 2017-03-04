using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace findmyhomeApi.Models
{
    public class Filtre
    {
        public string type { get; set; }
        public string typeBien { get; set; }
        public double prixMin { get; set; }
        public double prixMax { get; set; }
        public double surfaceMax { get; set; }
        public double surfaceMin { get; set; }
        public double aireRecherche { get; set; }   
    }
}
