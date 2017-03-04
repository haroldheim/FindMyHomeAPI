using findmyhomeApi.Models;
using findmyhomeApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace findmyhomeApi.Controllers
{
    [Route("api")]
    public class BienImmoController : Controller
    {
        public IBienImmo ImmoRepo { get; set; }
 
        public BienImmoController(IBienImmo _repo)
        {
            ImmoRepo = _repo;
        }
        
       
        [HttpPost("GetItemsWithGPS")]
        public IActionResult GetItemsWithGPS([FromBody] RequestGPSDto req)
        {
            
           var list = ImmoRepo.GetItemsWithGPS(req);
            if (list == null)
            {
                return BadRequest();
            }
            return new ObjectResult(list) ;
        }

        [HttpGet("GetItemDetailed/{id}")]
        public IActionResult GetItemDetailed(int id)
        {
            var item = ImmoRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("GetBienImage/{id}")]
        public FileResult GetBienImage(int id)
        {
            HttpContext.Response.ContentType = "application/jpg";
            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("C:\\Users\\findmyhome\\Desktop\\Web\\images\\" + id + ".jpg"), "application/jpg")
            {
                FileDownloadName = "bien" + id + ".jpg"
            };

            return result;
        }


        [HttpGet("Get3DModel/{id}")]
        public FileResult GetModel(int id)
        {
            HttpContext.Response.ContentType = "application/wt3";
            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("C:\\Users\\findmyhome\\Desktop\\Web\\models\\" + id +".wt3"), "application/wt3")
            {
                FileDownloadName = id  + ".wt3"
            };

            return result;
        }

        [HttpPost]
        public IActionResult Create([FromBody] BienImmo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ImmoRepo.Add(item);
            return CreatedAtRoute("GetBiens", new { Controller = "BienImmo", id = item.Id }, item);
        }
 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BienImmo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ImmoRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ImmoRepo.Update(item);
            return new NoContentResult();
        }
 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ImmoRepo.Remove(id);
        }
    }
}
