using Models.Models;
using Models.Enums;

namespace Services.Contracts
{
    public interface IWorkflowService
    {
        WorkflowDefine DefineNewWorkflow(WorkflowDefine workflowDefine, IEnumerable<int> userIds, IEnumerable<int> typeNameIds);
        WorkflowDefine EditDefinedWorkflow(object dto);
        void DeleteDefinedWorkflow(int id);
        List<WorkflowDefine> GetDefinedWorkflows(int[] ids);

        void CreateWorkflowTypeName(string name);
        IEnumerable<WorkflowTypeName> GetWorkflowTypes(int[] ids);
        void EditWorkflowTypeName(int id, string name);
        void DeleteWorkflowTypeName(int id);

        Workflow CreateNewRequest(object dto);
        Workflow EditRequestInfo(object dto);
        List<Workflow> GetRequests(int[] ids);
        Workflow ApproveRequest(int requestId);
        Workflow PassRequest(int requestId);
        Workflow AcceptResolutionForRequest(int requestId);
        Workflow WaitForActionRequest(int requestId);
        Workflow DenyRequest(int requestId);
        Workflow CancelRequest(int requestId);

        Workflow AddInvolveUser(int userId, int requestId);
        Workflow AddCommentToRequest(int requestId, string comment);
    }
}
