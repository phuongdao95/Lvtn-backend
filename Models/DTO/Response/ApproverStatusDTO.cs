using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Response
{
    public class ApproverStatusDTO
    {
        public string? Name { get; set; }
        public CommentStatus? Status { get; set; }
    }
}
