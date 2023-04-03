using annuaireAPI_db_first.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

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

        // GET api/values
        [HttpGet]
        public IEnumerable<Department> getAllDepartments()
        {
            try
            {
                return _context.Departments.ToList();
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<Department>();
            }
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult getDepartmentById(int id)
        {
            try
            {
                var department = _context.Departments.Where(s => s.Id.Equals(id)).FirstOrDefault();
                if (department == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(department);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        // POST api/values
        [HttpPost]
        public ActionResult addDepartment(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return CreatedAtAction(nameof(addDepartment), new { id = department.Id }, department);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
                return BadRequest(ex);
            }
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult updateDepartment(int id, [Bind("Id, Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    _context.SaveChanges();
                    return Ok(new { message = "Department updated" });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                    return BadRequest(ex);
                }
            }
            return Ok(new { message = "Department updated" });
        }

         // DELETE api/values/5
         [HttpDelete("{id}")]
         public ActionResult deleteDepartment(int id)
         {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound(nameof(deleteDepartment));
            }
            try
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
         }
    }
}
