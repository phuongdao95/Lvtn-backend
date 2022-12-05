using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Request
{
    public class WorkflowUserCommentDTO
    {
        public int UserId { get; set; }
        public int WorkflowId { get; set; }
        public string Content { get; set; }
    }
}
