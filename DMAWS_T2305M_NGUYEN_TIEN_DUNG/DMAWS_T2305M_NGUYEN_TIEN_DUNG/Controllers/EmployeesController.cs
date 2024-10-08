using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models;

namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.EmployeeId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/Employees/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(string name, DateTime? dobFrom, DateTime? dobTo)
        {
            var query = _context.Employees.AsQueryable();

            // Tìm kiếm theo tên
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.EmployeeName.Contains(name));
            }

            // Lọc theo khoảng thời gian ngày sinh
            if (dobFrom.HasValue)
            {
                query = query.Where(e => e.EmployeeDOB >= dobFrom.Value);
            }
            if (dobTo.HasValue)
            {
                query = query.Where(e => e.EmployeeDOB <= dobTo.Value);
            }

            return await query.ToListAsync();
        }
        // GET: api/Employees/{id}/projects
        [HttpGet("{id}/projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsForEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.ProjectEmployees)
                .ThenInclude(pe => pe.Projects)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee.ProjectEmployees.Select(pe => pe.Projects).ToList();
        }


    }
}
