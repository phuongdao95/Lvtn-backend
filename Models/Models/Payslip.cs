using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Payslip
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public long BaseSalary { get; set; }
        public string? Description { get; set; }
        public int? EmployeeId { get; set; }

        public User? Employee { get; set; }
    }
}
