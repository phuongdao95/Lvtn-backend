using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.WorkflowConfigs
{
    public class ApproveInfomation
    {
        public bool Sequence { get; set; }
        public int Minimum { get; set; }
        public List<int> DepartmentIds { get; set; }
        public List<int> CustomApprovers { get; set; }
    }
}
