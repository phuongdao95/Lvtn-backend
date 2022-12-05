
using Models.Enums;

namespace Models.Models
{
    public class Workflow
    {
        public int Id { get; set; }
        public WorkflowStatus Status { get; set; } = WorkflowStatus.Submitted;
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public int UserCreatedId { get; set; }

        public User UserCreated { get; set; }
        public List<WorkflowComment>? WorkflowComments { get; set; }
    }

    // Inherit table from Workflow, each is a different workflow
    public class NghiPhepWorkflow : Workflow
    {
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class NghiThaiSanWorkflow : Workflow
    {
        public DateTime StartDate { get; set; }
        public bool IsHusband { get; set; }
    }

    public class CheckInOutManualWorkflow : Workflow
    {
        public bool IsIn { get; set; }
        public DateTime CheckedTime { get; set; }
    }
}
