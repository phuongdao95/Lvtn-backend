using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Response
{
    public class PayslipInfoDTO
    {
        public int Id { get; set; }
        public string BaseSalary { get; set; }
        public string Description { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public string PayrollName { get; set; }
        public string PayrollId { get; set; }
    }
}
