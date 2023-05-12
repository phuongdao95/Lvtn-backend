using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Workflow.Request
{
    public class NewWorkflowDefine
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> WorkflowTypeNames { get; set; } = new List<int>();
        public List<int> DefaultAssignUsers { get; set; } = new List<int>();
    }
}
