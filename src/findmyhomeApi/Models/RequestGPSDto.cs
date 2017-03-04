using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace findmyhomeApi.Models
{
    public class RequestGPSDto 
    {
        public Filtre filtre { get; set; }
        public double coordLat { get; set; }
        public double coordLong { get; set; }
    }
}
