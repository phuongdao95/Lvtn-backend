
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

    //public class ChangeRankCareerPathWorkflow : Workflow
    //{
        // TODO: temporary disable this function because there's no database about career path yet
    //}

    public class HelpDeskWorkflow : Workflow
    {
        public int HelpDeskJobSelectId { get; set; }
        public int HelpDeskCriticalLevelWorkflowId { get; set; }
        public string OtherJob { get; set; }
        public string Notes { get; set; }

        public HelpDeskJobSelect HelpDeskJobSelect { get; set; }
        public HelpDeskCriticalLevel HelpDeskCriticalLevel { get; set; }
    }

    public class CostWorkflow : Workflow
    {
        public long Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
    }

    public class WFHWorkflow : Workflow { }

    public class AdvancePaymentWorkflow
    {
        public int MonthNumber { get; set; }
    }

    public class CheckInOutManualWorkflow : Workflow
    {
        public bool IsIn { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class OverTimeWorkflow : Workflow
    {
        public bool IsDepartment { get; set; } // If wrong -> Specific person
        public decimal TotalTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }

        public Department Department { get; set; }
        public User User { get; set; }
    }

    public class GeneralWorkflow : Workflow
    {
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
