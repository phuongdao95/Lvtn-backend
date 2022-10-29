using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.WorkflowConfigs
{
    public class OverTimeConfig
    {
        public ApproveInfomation ApproveInfo { get; set; }
        public int MaxHourInWeek { get; set; }
    }
}
