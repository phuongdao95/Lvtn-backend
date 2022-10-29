using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IWorkflowService
    {
        // Nghi phep
        void CreateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO);
        void UpdateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO);
        void UpdateWorkflowStatus(WorkflowApproverUpdateDTO request);
        void AddComment(WorkflowUserCommentDTO request);
        List<Workflow> GetWorkflowRequestsByUserId(int userId);
    }
}
