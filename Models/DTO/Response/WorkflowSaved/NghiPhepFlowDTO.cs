using Models.Enums;

namespace Models.DTO.Response.WorkflowSaved
{
    public class NghiPhepFlowDTO
    {
        public int FlowId { get; set; }
        public int UserCreatedId { get; set; }
        public string? Reason { get; set; }
        public WorkflowStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ApproverStatusDTO>? Approvers { get; set; }
        public List<WorkflowCommentDTO>? Comments { get; set; }
    }
}
