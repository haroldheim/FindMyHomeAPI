using findmyhomeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace findmyhomeApi.Repository
{
    public interface IBienImmo 
    {
        void Add(BienImmo item);
        IEnumerable<BienImmo> GetAll();
        IEnumerable<BienImmoLight> GetItemsWithGPS(RequestGPSDto req);
        BienImmo Find(int id);
        void Remove(int id);
        void Update(BienImmo item);
    }
}
