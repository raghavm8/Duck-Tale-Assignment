using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class EmployeeModel
    {
        [Key, Required]
        public int EmpId { get; set; }
        [Required]
        public string EmpName { get; set; }
        public int ManagerId { get; set; }
        [Required]
        public int EmpSalary { get; set; }

    }
}
