using findmyhomeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace findmyhomeApi.Repository
{
    public class BienImmoRepo : IBienImmo
    {
        findmyhomeContext _context;

        public BienImmoRepo(findmyhomeContext context)
        {
            _context = context;
        }

        static List<BienImmo> BienImmoList = new List<BienImmo>();

        public void Add(BienImmo item)
        {
            //BienImmoList.Add(item);
            _context.BienImmo.Add(item);
            _context.SaveChanges(); 
        }

        public BienImmo Find(int key)
        {
            BienImmo item;
            item = _context.BienImmo.Find(key);
            return item;
        }

        public IEnumerable<BienImmo> GetAll()
        {
            //return BienImmoList;
            return _context.BienImmo.ToList();
        }
        
        public IEnumerable<BienImmoLight> GetItemsWithGPS(RequestGPSDto req)
        {
            
            double earthRadius = 6378137;
            double latPlus = req.coordLat + (req.filtre.aireRecherche / earthRadius) * (180 / Math.PI);
            double latMoins = req.coordLat - (req.filtre.aireRecherche / earthRadius) * (180 / Math.PI);
            double longMoins = req.coordLong - (req.filtre.aireRecherche / (earthRadius * Math.Cos(Math.PI* req.coordLat /180))) * (180 / Math.PI);
            double longPlus = req.coordLong + (req.filtre.aireRecherche / (earthRadius * Math.Cos(Math.PI* req.coordLat / 180))) * (180 / Math.PI);

            var query = _context.BienImmo
             .Where(u => u.CoordLat >= latMoins
             && u.CoordLat <= latPlus
             && u.CoordLong >= longMoins
             && u.CoordLong <= longPlus
                    )
             .Select(u => new BienImmoLight
             {
                 Id = u.Id,
                 CoordLat = u.CoordLat,
                 CoordLong = u.CoordLong,
                 Soustitre = u.Soustitre,
                 Prix = u.Prix,
                 TypeBien = u.TypeBien,
                 Type = u.Type,
                 Titre = u.Titre,
                 Photo = u.Photo,
                 Surface = u.Surface
             });
            /*
            if(req.filtre.prixMax != 0)
                query.Where(u => u.Prix <= req.filtre.prixMax);

            if (req.filtre.prixMin != 0)
                query.Where(u => u.Prix >= req.filtre.prixMin);

            if (req.filtre.surfaceMax != 0)
                query.Where(u => u.Surface <= req.filtre.surfaceMax);

            if (req.filtre.surfaceMin != 0)
                query.Where(u => u.Surface >= req.filtre.surfaceMin);

            if (!req.filtre.typeBien.Equals(null))
                query.Where(u => u.TypeBien == req.filtre.typeBien);

            if (!req.filtre.type.Equals(null))
                query.Where(u => u.Type == req.filtre.type);
            */
            return query.ToList();
        }
        
        public void Remove(int Id)
        {
            var itemToRemove = BienImmoList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                BienImmoList.Remove(itemToRemove);
        }

        public void Update(BienImmo item)
        {
            var itemToUpdate = BienImmoList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Titre = item.Titre;
            }
        }
    }
}
