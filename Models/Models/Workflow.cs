
using Models.Enums;

namespace Models.Models
{
    public class Workflow
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UserApprovedId { get; set; }
        public int? WorkflowDefineId { get; set; }


        public User? UserCreated { get; set; } // Who created the request
        public User? UserApproved { get; set; } // Who approved the request
        public WorkflowDefine? WorkflowDefine { get; set; } // Type of the request (for search query)
        public List<User>? InvolvedUsers { get; set; } // Add more people to see the problem if needed
        public List<WorkflowStatus>? WorkflowStatuses { get; set; } // All statuses of the request
        public List<WorkflowComment>? WorkflowComments { get; set; } // All comments of the request
        public List<WorkflowDocument>? WorkflowDocuments { get; set; } // All documents of the request
    }
}
