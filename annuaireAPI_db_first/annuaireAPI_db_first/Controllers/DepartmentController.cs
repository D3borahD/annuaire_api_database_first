using annuaireAPI_db_first.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace annuaireAPI_db_first.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class DepartmentsController : ControllerBase
        {
            private readonly AnnuaireContext _context;

            public DepartmentsController(AnnuaireContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Department>>> getAllDepartments()
            {
                return await _context.Departments.ToListAsync();
            }


            // GET api/values/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Department>> getDepartmentById(int id)
            {
                var department = await _context.Departments.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
                if (department == null)
                {
                    return NotFound();
                }
                else
                {
                    return department;
                }
            }

            // POST api/values
            [HttpPost]
            public async Task<ActionResult<Site>> addOneDepartment(Department department)
            {
                // vérifier les données reçues du navigateur ...
                // ...
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(addOneDepartment), new { id = department.Id }, department);
            }

            // PUT api/values/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> deleteDepartment(int id)
            {
                var site = await _context.Sites.FindAsync(id);
                if (site == null)
                {
                    return NotFound(nameof(deleteDepartment));
                }
                _context.Sites.Remove(site);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }



        /* // GET: DepartmentController
         public ActionResult Index()
         {
             return View();
         }

         // GET: DepartmentController/Details/5
         public ActionResult Details(int id)
         {
             return View();
         }

         // GET: DepartmentController/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: DepartmentController/Create
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create(IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }

         // GET: DepartmentController/Edit/5
         public ActionResult Edit(int id)
         {
             return View();
         }

         // POST: DepartmentController/Edit/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }

         // GET: DepartmentController/Delete/5
         public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: DepartmentController/Delete/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Delete(int id, IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }*/
    
}
