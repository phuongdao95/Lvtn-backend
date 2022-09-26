using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Request
{
    public class DepartmentDTO
    {
        public string? Name { get; set; }
        public int? ManagerId { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string? Detail { get; set; }
        public List<int>? TeamIds { get; set; }
    }
}
