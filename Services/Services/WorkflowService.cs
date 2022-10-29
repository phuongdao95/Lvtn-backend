using AutoMapper;
using Models.DTO.Request;
using Models.DTO.WorkflowConfigs;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using System.Text.Json;
using System.Linq;

namespace Services.Services
{
    public class WorkflowService : IWorkflowService
    {
        private EmsContext _context;
        private IMapper _mapper;
        private WorkflowConfigs _workflowConfigs;
        public WorkflowService(EmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            using (var r = new StreamReader(@"../Models/DTO/WorkflowConfigs/workflowconfigs.json"))
            {
                string json = r.ReadToEnd();
                _workflowConfigs = JsonSerializer.Deserialize<WorkflowConfigs>(json);
            }
        }

        public void AddComment(WorkflowUserCommentDTO request)
        {
            var workflow = _context.Workflows.FirstOrDefault(w => w.Id == request.WorkflowId);
            try
            {
                workflow.WorkflowComments.Add(
                    new WorkflowComment()
                    {
                        UserId = request.UserId,
                        Comment = request.Content,
                        RegularComment = true
                    });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot find resource", ex);
            }
        }

        public List<Workflow> GetWorkflowRequestsByUserId(int userId)
        {
            return _context.Workflows.Where(w => w.UserCreatedId == userId).ToList();
        }

        /*
         * For every workflows: 
         * + Create: add record of that flow, create initial comments that are for approvers
         * + Edit: only edit information of flow
         * + Delete: cannot delete flow, only set it to cancel status
         * + Read: load flow and comments
         */

        // Nghi phep
        public void CreateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO)
        {
            var nghiPhepWorkflow = new NghiPhepWorkflow()
            {
                UserCreated = _context.Users.FirstOrDefault(u => u.Id == nghiPhepDTO.UserId),
                Reason = nghiPhepDTO.Reason,
                StartDate = nghiPhepDTO.StartDate,
                EndDate = nghiPhepDTO.EndDate
            };
            var nghiPhepConfig = _workflowConfigs.NghiPhepConfig;
            var listApprovers = GetApproverList(nghiPhepConfig.ApproveInfo.CustomApprovers, nghiPhepConfig.ApproveInfo.DepartmentIds) ?? new List<User?>();

            nghiPhepWorkflow.WorkflowComments = listApprovers.Where(x => x != null).Select(a => new WorkflowComment()
            {
                User = a,
                RegularComment = false
            }).ToList();

            _context.NghiPhepWorkflows.Add(nghiPhepWorkflow);
            _context.SaveChanges();
        }
        public void UpdateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO)
        {
            var nghiPhep = _context.NghiPhepWorkflows.FirstOrDefault(n => n.Id == nghiPhepDTO.Id);
            try
            {
                nghiPhep.Reason = nghiPhepDTO.Reason;
                nghiPhep.StartDate = nghiPhepDTO.StartDate;
                nghiPhep.EndDate = nghiPhepDTO.EndDate;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Error handling
            }
        }


        public void UpdateWorkflowStatus(WorkflowApproverUpdateDTO request)
        {
            var workflow = _context.Workflows.FirstOrDefault(w => w.Id == request.WorkflowId);
            if (workflow != null)
            {
                // Set status updated of approver to that workflow
                var statusComment = workflow.WorkflowComments.FirstOrDefault(w => w.UserId == request.ApproverId && w.RegularComment == false);
                statusComment.Status = request.Status;

                // After set new status, check if workflow is approve of denied
                var statusList = workflow.WorkflowComments.Where(wc => wc.RegularComment == false).Select(wc => wc.Status).ToList();
                foreach(var status in statusList)
                {
                    if (status == Models.Enums.CommentStatus.Denied)
                    {
                        workflow.Status = Models.Enums.WorkflowStatus.Denied;
                        break;
                    }

                }
                _context.SaveChanges();
            }
        }

        private IEnumerable<User?> GetApproverList(List<int> userIds, List<int> departmentIds)
        {
            var listUsers = _context.Users.Where(u => userIds.Contains(u.Id)).ToList();
            var listDepartmentLeaders = _context.Departments.Where(d => departmentIds.Contains(d.Id)).Select(d => d.Manager);
            return (listUsers ?? Enumerable.Empty<User>()).Union(listDepartmentLeaders).ToList();
        }
    }
}
