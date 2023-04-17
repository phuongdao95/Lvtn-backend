using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Response
{
    public class TimeManageResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeExpect { get; set; }
        public int TimeReal { get; set; }
        public string? TeamName { get; set; }
        public string? Gender { get; set; }
        public int TimeMiss { get; set; }
        public string Role { get; set; }
    }
}
