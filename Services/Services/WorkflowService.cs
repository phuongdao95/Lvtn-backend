using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using System.Text.Json;
using System.Linq;
using Models.DTO.Response;
using Models.DTO.Response.WorkflowSaved;
using Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Services.Services
{
    public class WorkflowService : IWorkflowService
    {
        private EmsContext _context;
        private IMapper _mapper;
        public WorkflowService(EmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /*------------  ------------*/

        public void CreateWorkflowTypeName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkflowTypeName> GetWorkflowTypes(int[] ids)
        {
            throw new NotImplementedException();
        }

        public void EditWorkflowTypeName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkflowTypeName(int id)
        {
            throw new NotImplementedException();
        }

        /*------------  ------------*/
        public List<WorkflowDefine> GetDefinedWorkflows(int[] ids)
        {
            throw new NotImplementedException();
        }

        public WorkflowDefine DefineNewWorkflow(WorkflowDefine workflowDefine, IEnumerable<int> userIds, IEnumerable<int> typeNameIds)
        {
            var listUser = _context.Users.Where(u => userIds.Contains(u.Id));
            var listWfTypeNames = _context.WorkflowTypeNames.Where(u => typeNameIds.Contains(u.Id));

            workflowDefine.Id = 0; // make sure to create
            workflowDefine.DefaultAssignUsers = listUser.ToList();
            workflowDefine.WorkflowTypeNames = listWfTypeNames.ToList();

            _context.WorkflowDefines.Add(workflowDefine);
            _context.SaveChanges();

            return workflowDefine;
        }

        public WorkflowDefine EditDefinedWorkflow(object dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteDefinedWorkflow(int id)
        {
            throw new NotImplementedException();
        }

        /*------------  ------------*/
        public List<Workflow> GetRequests(int[] ids)
        {
            throw new NotImplementedException();
        }

        public Workflow CreateNewRequest(object dto)
        {
            throw new NotImplementedException();
        }

        public Workflow EditRequestInfo(object dto)
        {
            throw new NotImplementedException();
        }

        /*------------  ------------*/
        public Workflow AcceptResolutionForRequest(int requestId)
        {
            throw new NotImplementedException();
        }

        public Workflow AddCommentToRequest(int requestId, string comment)
        {
            throw new NotImplementedException();
        }

        public Workflow AddInvolveUser(int userId, int requestId)
        {
            throw new NotImplementedException();
        }

        public Workflow ApproveRequest(int requestId)
        {
            throw new NotImplementedException();
        }

        public Workflow CancelRequest(int requestId)
        {
            throw new NotImplementedException();
        }

        public Workflow DenyRequest(int requestId)
        {
            throw new NotImplementedException();
        }

        public Workflow PassRequest(int requestId)
        {
            throw new NotImplementedException();
        }

        public Workflow WaitForActionRequest(int requestId)
        {
            throw new NotImplementedException();
        }
    }
}
