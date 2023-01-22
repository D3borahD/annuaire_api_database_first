using annuaireAPI_db_first.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace annuaireAPI_db_first.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AnnuaireContext _context;

        public EmployeesController(AnnuaireContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> getAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> getEmployeeById(int id)
        {
            var employee = await _context.Employees.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return employee;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Site>> addOneEmployee(Employee employee)
        {
            // vérifier les données reçues du navigateur ...
            // ...
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(addOneEmployee), new { id = employee.Id }, employee);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound(nameof(deleteEmployee));
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }


    /*  public class EmployeeController : Controller
      {
          // GET: EmployeeController
          public ActionResult Index()
          {
              return View();
          }

          // GET: EmployeeController/Details/5
          public ActionResult Details(int id)
          {
              return View();
          }

          // GET: EmployeeController/Create
          public ActionResult Create()
          {
              return View();
          }

          // POST: EmployeeController/Create
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

          // GET: EmployeeController/Edit/5
          public ActionResult Edit(int id)
          {
              return View();
          }

          // POST: EmployeeController/Edit/5
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

          // GET: EmployeeController/Delete/5
          public ActionResult Delete(int id)
          {
              return View();
          }

          // POST: EmployeeController/Delete/5
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
          }
      }*/
}
