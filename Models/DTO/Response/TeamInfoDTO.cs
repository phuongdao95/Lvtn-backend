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
        public string? Description { get; set; }

        public int? LeaderId { get; set; }
        public string? LeaderName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public List<int>? MemberIds { get; set; }
        public List<string>? MemberNames { get; set; }
    }
}
