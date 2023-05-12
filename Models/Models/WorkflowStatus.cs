using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class WorkflowStatus
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkflowId { get; set; }
        public WorkflowStatusEnum Status { get; set; }
        public string? StatusComment { get; set; }
        public DateTime TimeStamp { get; set; }

        public Workflow Workflow { get; set; }
        public User User { get; set; }
    }
}
