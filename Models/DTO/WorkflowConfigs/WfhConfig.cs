using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.WorkflowConfigs
{
    public class WfhConfig
    {
        public ApproveInfomation ApproveInfo { get; set; }
        public int MaxDayInWeek { get; set; }
    }
}
