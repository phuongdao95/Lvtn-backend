using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Response
{
    public class DepartmentInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }

        public int? ParentDepartmentId { get; set; }
        public string? ParentDepartmentName { get; set; }
    }
}
