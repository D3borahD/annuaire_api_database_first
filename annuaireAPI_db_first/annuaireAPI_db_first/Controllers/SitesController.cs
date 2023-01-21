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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> getAllSites()
        {
            return await _context.Sites.ToListAsync();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> getSiteById(int id)
        {
            var site = await _context.Sites.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
            if (site == null)
            {
                return NotFound();
            }
            else
            {
                return site;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Site>> addOneSite(Site site)
        {
            // vérifier les données reçues du navigateur ...
            // ...
            _context.Sites.Add(site);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(addOneSite), new { id = site.Id }, site);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound(nameof(deleteSite));
            }
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    /* public class SitesController : Controller
     {
         private readonly AnnuaireContext _context;

         public SitesController(AnnuaireContext context)
         {
             _context = context;
         }

         // GET: Sites
         public async Task<IActionResult> Index()
         {
               return View(await _context.Sites.ToListAsync());
         }

         // GET: Sites/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null || _context.Sites == null)
             {
                 return NotFound();
             }

             var site = await _context.Sites
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (site == null)
             {
                 return NotFound();
             }

             return View(site);
         }

         // GET: Sites/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Sites/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Id,Name")] Site site)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(site);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(site);
         }

         // GET: Sites/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null || _context.Sites == null)
             {
                 return NotFound();
             }

             var site = await _context.Sites.FindAsync(id);
             if (site == null)
             {
                 return NotFound();
             }
             return View(site);
         }

         // POST: Sites/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Site site)
         {
             if (id != site.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(site);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!SiteExists(site.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(site);
         }

         // GET: Sites/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null || _context.Sites == null)
             {
                 return NotFound();
             }

             var site = await _context.Sites
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (site == null)
             {
                 return NotFound();
             }

             return View(site);
         }

         // POST: Sites/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             if (_context.Sites == null)
             {
                 return Problem("Entity set 'AnnuaireContext.Sites'  is null.");
             }
             var site = await _context.Sites.FindAsync(id);
             if (site != null)
             {
                 _context.Sites.Remove(site);
             }

             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool SiteExists(int id)
         {
           return _context.Sites.Any(e => e.Id == id);
         }
     }*/
}
