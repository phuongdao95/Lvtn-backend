using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Request
{
    public class WorkflowApproverUpdateDTO
    {
        public int ApproverId { get; set; }
        public int WorkflowId { get; set; }
        public CommentStatus Status { get; set; }
    }
}
