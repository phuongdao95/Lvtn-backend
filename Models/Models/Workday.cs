using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Workday
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        DateOnly Date { get; set; }
        // Minutes pass midnight
        public int CheckAt { get; set; }
    }
}
