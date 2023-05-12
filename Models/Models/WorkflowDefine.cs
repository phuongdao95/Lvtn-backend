using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class WorkflowDefine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<WorkflowTypeName>? WorkflowTypeNames { get; set; }
        public List<User>? DefaultAssignUsers { get; set; }
    }
}
