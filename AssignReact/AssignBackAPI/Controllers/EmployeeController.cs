using Microsoft.AspNetCore.Mvc;
using Assignment.DBHelper;
using Assignment.Models;

namespace AssignBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> Getemployees()
        {
          if (_context.employees == null)
          {
              return NotFound();
          }
            IList<EmployeeModel> employees = _context.employees.OrderBy(i => i.EmpId).ToList<EmployeeModel>();
            return Ok(employees);
        }

        [HttpGet("Task1")]
        public ActionResult<IDictionary<string, string>> Task1()
        {
            if (_context.employees == null)
            {
                return NotFound();
            }
            IList<EmployeeModel> employees = _context.employees.ToList();
            IDictionary<string, string> result = new Dictionary<string, string>();

            if (employees.Count > 0)
            {
                foreach (var emp in employees)
                {
                    var key = emp.EmpName;
                    int managerId = emp.ManagerId;
                    string? managerName = string.Empty;
                    if (managerId != 0)
                        managerName = employees?.FirstOrDefault(item => item.EmpId == managerId).EmpName;
                    else
                        managerName = "No Manager";
                    result.Add(key, managerName);
                }
                return Ok(result);
            }
            else
                return NotFound();
        }

        [HttpGet("Task2")]
        public ActionResult<IDictionary<string, string>> Task2()
        {
            if (_context.employees == null)
            {
                return NotFound();
            }

            IList<EmployeeModel> employees = _context.employees.ToList();
            IList<int> managers = _context.employees.Select(i => i.ManagerId).Distinct().ToList();
            IDictionary<string, int> result = new Dictionary<string, int>();

            if (employees != null)
            {
                foreach (var managerId in managers)
                {
                    if (managerId == 0)
                        continue;
                    string managerName = employees.FirstOrDefault(i => i.EmpId == managerId).EmpName;
                    int empNumber = employees.Count(i => i.ManagerId == managerId);
                    result.Add(managerName, empNumber);
                }
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Task3")]
        public ActionResult<IDictionary<string, string>> Task3()
        {
            if (_context.employees == null)
            {
                return NotFound();
            }

            IList<EmployeeModel> employees = _context.employees.ToList();
            IList<int> managers = _context.employees.Select(i => i.ManagerId).Distinct().ToList();
            IDictionary<string, int> result = new Dictionary<string, int>();

            if (employees != null)
            {
                foreach (var managerId in managers)
                {
                    if (managerId == 0)
                        continue;
                    EmployeeModel employee = employees.FirstOrDefault(item => item.EmpId == managerId);
                    result.Add(employee.EmpName, employee.EmpSalary);
                }
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Task4")]
        public ActionResult<IDictionary<string, string>> Task4()
        {
            if (_context.employees == null)
            {
                return NotFound();
            }

            IList<EmployeeModel> employees = _context.employees.ToList();

            if (employees != null)
            {
                int largest = employees.MaxBy(i => i.EmpSalary).EmpSalary;
                int secondLargest = int.MinValue;
                string employeeName = string.Empty;
                foreach (var emp in employees)
                {
                    if (emp.EmpSalary < largest)
                    {
                        if(emp.EmpSalary > secondLargest)
                        {
                            secondLargest=emp.EmpSalary;
                            employeeName = emp.EmpName;
                        }
                    }
                }
                Dictionary<string, int> result = new Dictionary<string, int>();
                result.Add(employeeName, secondLargest);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
