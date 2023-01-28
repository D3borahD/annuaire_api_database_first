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

        // GET api/value
        [HttpGet]
        public IEnumerable<Employee> getAllEmployees()
        {
            return _context.Employees.ToList();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult getEmployeeById(int id)
        {
            var employee = _context.Employees.Where(s => s.Id.Equals(id)).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult addOneEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);

            //return CreatedAtAction(nameof(addOneEmployee), new { id = employee.Id }, employee);
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult updateEmployee(int id,Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                    return Ok(new { message = "Employee updated" });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                    return BadRequest(ex);
                }
            }
            return Ok(new { message = "Employee updated"});
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult deleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound(nameof(deleteEmployee));
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
