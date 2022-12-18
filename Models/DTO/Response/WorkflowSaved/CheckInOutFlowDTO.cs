using Models.Enums;

namespace Models.DTO.Response.WorkflowSaved
{
    public class CheckInOutFlowDTO
    {
        public int FlowId { get; set; }
        public int UserCreatedId { get; set; }
        public string UserCreatedName { get; set; }
        public DateTime CreatedTime { get; set; }
        public WorkflowStatus Status { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public List<ApproverStatusDTO>? Approvers { get; set; }
        public List<WorkflowCommentDTO>? Comments { get; set; }
    }
}
