
using Models.Enums;

namespace Models.DTO.Response.WorkflowSaved
{
    public class NghiThaiSanFlowDTO
    {
        public int FlowId { get; set; }
        public int UserCreatedId { get; set; }
        public WorkflowStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsHusBand { get; set; }
        public List<ApproverStatusDTO>? Approvers { get; set; }
        public List<WorkflowCommentDTO>? Comments { get; set; }
    }
}
