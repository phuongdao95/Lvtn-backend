using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.WorkflowConfigs
{
    public class WorkflowConfigs
    {
        public NghiPhepConfig NghiPhepConfig { get; set; }
        public NghiThaiSanConfig NghiThaiSanConfig { get; set; }
        public HelpDeskConfig HelpDeskConfig { get; set; }
        public CostConfig CostConfig { get; set; }
        public WfhConfig WfhConfig { get; set; }
        public AdvancePaymentConfig AdvancePaymentConfig { get; set; }
        public CheckInOutManualConfig CheckInOutManualConfig { get; set; }
        public OverTimeConfig OverTimeConfig { get; set; }
    }
}
