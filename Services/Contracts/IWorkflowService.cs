using Models.DTO.Request;
using Models.DTO.Response;
using Models.DTO.Response.WorkflowConfigsDTO;
using Models.DTO.Response.WorkflowSaved;
using Models.Models;
using Models.Enums;

namespace Services.Contracts
{
    public interface IWorkflowService
    {
        // Nghi phep
        void CreateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO);
        void UpdateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO);
        NghiPhepFlowDTO LoadNghiPhep(int flowId);
        InitialWorkflowDTO LoadInitialNghiPhep(int userId);

        //Nghi thai san
        void CreateNghiThaiSanWorkflow(NghiThaiSanDTO nghiThaiSanDTO);
        void UpdateNghiThaiSanWorkflow(NghiThaiSanDTO nghiPhepDTO);
        NghiThaiSanFlowDTO LoadNghiThaiSan(int flowId);
        InitialWorkflowDTO LoadInitialNghiThaiSan(int userId);

        //Check in-out manual
        void CreateCheckInOutWorkflow(CheckInOutDTO checkInOutDTO);
        CheckInOutFlowDTO LoadCheckInOut(int flowId);
        InitialWorkflowDTO LoadInitialCheckInOut(int userId);

        //General

        void UpdateWorkflowStatus(WorkflowApproverUpdateDTO request);
        void AddComment(WorkflowUserCommentDTO request);
        List<Workflow> GetWorkflowRequestsByUserId(int userId);
        List<Workflow> GetWorkflowRequestsByApproverId(int approverId);

        public DepartmentAndUserSelectionDTO GetSelections();
    }
}
