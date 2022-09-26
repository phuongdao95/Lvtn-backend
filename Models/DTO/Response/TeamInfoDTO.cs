using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Response
{
    public class TeamInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descriptionn { get; set; }

        public int? LeaderId { get; set; }
        public int? LeaderName { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentName { get; set; }
    }
}
