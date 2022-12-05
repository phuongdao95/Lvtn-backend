namespace Models.DTO.Response
{
    public class InitialWorkflowDTO
    {
        public decimal? LeaveBalance { get; set; }

        public List<ApproverStatusDTO>? Approvers { get; set; }
    }
}
