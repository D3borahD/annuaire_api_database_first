using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using annuaireAPI_db_first.Models;

namespace annuaireAPI_db_first.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        private readonly AnnuaireContext _context;

        public SitesController(AnnuaireContext context)
        {
            _context = context;
        }

        // GET api/value
        [HttpGet]
        public IEnumerable<Site> getAllSites()
        {
            try
            {
                return _context.Sites.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Site>();
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult getSiteById(int id)
        {
            try
            {
                var site = _context.Sites.Where(s => s.Id.Equals(id)).FirstOrDefault();
                if (site == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(site);
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST api/values
        [HttpPost]
        public ActionResult addSite(Site site)
        {
            try {
                _context.Sites.Add(site);
                _context.SaveChanges();
                return CreatedAtAction(nameof(addSite), new { id = site.Id }, site);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
                return BadRequest(ex);
            }  
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult updateSite(int id, [Bind("Id, Name")] Site site)
        {
           if (id !=site.Id)
            {
                return NotFound();
            }
           if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    _context.SaveChanges();
                    return Ok( new { message = "Site updated" });  
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                    return BadRequest(ex);
                }
            }
            return Ok(new {message = "Site updated"});
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult deleteSite(int id)
        {
            var site = _context.Sites.Find(id);
            if (site == null)
            {
                return NotFound(nameof(deleteSite));
            }
            try
            {
                _context.Sites.Remove(site);
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }

  
}
