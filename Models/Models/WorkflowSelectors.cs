using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class HelpDeskJobSelect
    {
        public int Id { get; set; }
        public string Job { get; set; }
    }

    public class HelpDeskCriticalLevel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
    }
}
