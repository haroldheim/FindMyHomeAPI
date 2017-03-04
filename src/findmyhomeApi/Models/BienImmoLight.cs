using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace findmyhomeApi.Models
{
    public class BienImmoLight
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Soustitre { get; set; }
        public double CoordLong { get; set; }
        public double CoordLat { get; set; }
        public string Type { get; set; }
        public string TypeBien { get; set; }
        public double Prix { get; set; }
        public double Surface { get; set; }
        public string Photo { get; set; }
    }
}
