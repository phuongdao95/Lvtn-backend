using AutoMapper;
using Models.DTO.Request;
using Models.DTO.WorkflowConfigs;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using System.Text.Json;
using System.Linq;
using Models.DTO.Response.WorkflowConfigsDTO;
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
            var workflow = _context.Workflows.Include(w => w.WorkflowComments).FirstOrDefault(w => w.Id == request.WorkflowId);
            try
            {
                workflow.WorkflowComments.Add(
                    new WorkflowComment()
                    {
                        UserId = request.UserId,
                        Comment = request.Content,
                        RegularComment = true,
                        Status = CommentStatus.None,
                        Action = WorkflowActionType.Comment
                    });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot find resource", ex);
            }
        }

        public void UpdateWorkflowStatus(WorkflowApproverUpdateDTO request)
        {
            var workflow = _context.Workflows.Include(w => w.WorkflowComments).FirstOrDefault(w => w.Id == request.WorkflowId);
            if (workflow != null)
            {
                // Set status updated of approver to that workflow
                workflow.WorkflowComments.Add(new WorkflowComment()
                {
                    UserId = request.ApproverId,
                    Status = request.Status,
                    RegularComment = false,
                    Action = request.Status switch
                    {
                        _ when request.Status == CommentStatus.Approved => WorkflowActionType.ApproveWorkflow,
                        _ when request.Status == CommentStatus.Denied => WorkflowActionType.DenyWorkflow,
                        _ => throw new Exception("Not allow")
                    }
                });

                // After set new status, check if workflow is approved or denied or submitted
                var statusList = workflow.WorkflowComments
                        .GroupBy(w => w.UserId)
                        .SelectMany(w => w.OrderByDescending(w => w.TimeStamp).Take(1))
                        .Select(w => w.Status).Distinct().ToList();
                if (statusList.Any())
                {
                    if (statusList.Contains(CommentStatus.Denied))
                    {
                        workflow.Status = WorkflowStatus.Denied;
                    }
                    else if (statusList.Contains(CommentStatus.Pending))
                    {
                        workflow.Status = WorkflowStatus.Submitted;
                    }
                    else
                    {
                        // It's more complex but it's just for demo
                        workflow.Status = WorkflowStatus.Approved;
                    }
                }
                _context.SaveChanges();
            }
        }

        public List<Workflow> GetWorkflowRequestsByUserId(int userId)
        {
            return _context.Workflows.Where(w => w.UserCreatedId == userId).ToList();
        }

        public List<Workflow> GetWorkflowRequestsByApproverId(int approverId)
        {
            try
            {
                return _context.Workflows.Include(w => w.WorkflowComments).Where(w => w.WorkflowComments.Select(wc => wc.UserId).Contains(approverId)).ToList();
            }
            catch
            {
                return new List<Workflow>();
            }
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
                UserCreatedId = nghiPhepDTO.UserId,
                Reason = nghiPhepDTO?.Reason ?? "",
                StartDate = nghiPhepDTO.StartDate,
                EndDate = nghiPhepDTO.EndDate
            };
            var nghiPhepConfig = _workflowConfigs.NghiPhepConfig;
            var listApprovers = GetApproverList(nghiPhepConfig.ApproveInfo.CustomApprovers, nghiPhepConfig.ApproveInfo.DepartmentIds) ?? new List<User?>();

            nghiPhepWorkflow.WorkflowComments = listApprovers.Where(x => x != null).Select(a => new WorkflowComment()
            {
                User = a,
                Status = CommentStatus.Pending,
                RegularComment = false,
                Action = WorkflowActionType.NewWorkflow
            }).ToList();

            _context.NghiPhepWorkflows.Add(nghiPhepWorkflow);
            _context.SaveChanges();
        }
        public void UpdateNghiPhepWorkflow(NghiPhepDTO nghiPhepDTO)
        {
            var nghiPhep = _context.NghiPhepWorkflows.Include(f => f.WorkflowComments).FirstOrDefault(n => n.Id == nghiPhepDTO.Id);
            try
            {
                if (nghiPhep?.Status == WorkflowStatus.Denied)
                {
                    throw new Exception("Cannot change denied flow!");
                }
                nghiPhep.Reason = nghiPhepDTO?.Reason ?? "";
                nghiPhep.StartDate = nghiPhepDTO?.StartDate ?? new DateTime();
                nghiPhep.EndDate = nghiPhepDTO?.EndDate ?? new DateTime();
                nghiPhep.WorkflowComments?.Add(new WorkflowComment()
                {
                    UserId = nghiPhep.UserCreatedId,
                    Status = CommentStatus.None,
                    Action = WorkflowActionType.MakeChangeWorkflow
                });

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NghiPhepFlowDTO LoadNghiPhep(int flowId)
        {
            try
            {
                var nghiPhepFlow = _context.NghiPhepWorkflows.Include(f => f.WorkflowComments).ThenInclude(c => c.User).FirstOrDefault(w => w.Id == flowId);
                var approveCommentList = nghiPhepFlow?.WorkflowComments
                        .Where(wc => wc.RegularComment == false)
                        .GroupBy(w => w.UserId)
                        .SelectMany(w => w.OrderByDescending(w => w.TimeStamp).Take(1))
                        .ToList();
                return new NghiPhepFlowDTO()
                {
                    FlowId = flowId,
                    UserCreatedId = nghiPhepFlow?.UserCreatedId ?? 0,
                    Reason = nghiPhepFlow.Reason,
                    Status = nghiPhepFlow.Status,
                    StartDate = nghiPhepFlow.StartDate,
                    EndDate = nghiPhepFlow.EndDate,

                    Approvers = approveCommentList?.Select(c => new ApproverStatusDTO()
                    {
                        Name = c.User.Name,
                        Status = c.Status
                    }).ToList(),
                    Comments = nghiPhepFlow?.WorkflowComments?.OrderBy(wc => wc.TimeStamp).Select(wc => new WorkflowCommentDTO()
                    {
                        Name = wc.User.Name ?? "Người dùng lỗi",
                        TimeStamp = wc.TimeStamp,
                        Text = wc.Action switch
                        {
                            _ when wc.Action == WorkflowActionType.Comment => wc.Comment ?? "Bình luận bị lỗi",
                            _ when wc.Action == WorkflowActionType.MakeChangeWorkflow => "Đã sửa thông tin yêu cầu",
                            _ when wc.Action == WorkflowActionType.NewWorkflow => "Đã được hệ thống thông báo về yêu cầu mới",
                            _ when wc.Action == WorkflowActionType.ApproveWorkflow => "Đã sửa trạng thái bản thân thành \"Đã chấp thuận\"",
                            _ when wc.Action == WorkflowActionType.DenyWorkflow => "Đã sửa trạng thái bản thân thành \"Đã từ chối\"",
                            _ => ""
                        }
                    }).ToList()
                };
            }
            catch
            {
                return new NghiPhepFlowDTO();
            }
        }
        public InitialWorkflowDTO LoadInitialNghiPhep(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                var nghiPhepConfig = _workflowConfigs.NghiPhepConfig;
                var listApprovers = GetApproverList(nghiPhepConfig.ApproveInfo.CustomApprovers, nghiPhepConfig.ApproveInfo.DepartmentIds).Where(a => a != null) ?? new List<User?>();
                return new InitialWorkflowDTO()
                {
                    LeaveBalance = user.LeaveBalance,
                    Approvers = listApprovers.Select(a => new ApproverStatusDTO()
                    {
                        Name = a.Name,
                        Status = CommentStatus.Pending
                    }).ToList()
                };
            }
            catch (Exception)
            {
                return new InitialWorkflowDTO();
            }
        }

        // Nghi thai san
        public void CreateNghiThaiSanWorkflow(NghiThaiSanDTO nghiThaiSanDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == nghiThaiSanDTO.UserId);
            var nghiThaiSanWorkflow = new NghiThaiSanWorkflow()
            {
                UserCreatedId = nghiThaiSanDTO.UserId,
                IsHusband = user?.Sex ?? false,
                StartDate = nghiThaiSanDTO.StartDate
            };
            var nghiThaiSanConfig = _workflowConfigs.NghiThaiSanConfig;
            var listApprovers = GetApproverList(nghiThaiSanConfig.ApproveInfo.CustomApprovers, nghiThaiSanConfig.ApproveInfo.DepartmentIds).Where(a => a != null) ?? new List<User?>();

            nghiThaiSanWorkflow.WorkflowComments = listApprovers.Where(x => x != null).Select(a => new WorkflowComment()
            {
                User = a,
                Status = CommentStatus.Pending,
                RegularComment = false,
                Action = WorkflowActionType.NewWorkflow
            }).ToList();

            _context.NghiThaiSanWorkflows.Add(nghiThaiSanWorkflow);
            _context.SaveChanges();
        }
        public void UpdateNghiThaiSanWorkflow(NghiThaiSanDTO nghiThaiSanDTO)
        {
            var nghiThaiSan = _context.NghiThaiSanWorkflows.FirstOrDefault(n => n.Id == nghiThaiSanDTO.Id);
            try
            {
                if (nghiThaiSan?.Status == WorkflowStatus.Denied)
                {
                    throw new Exception("Cannot change denied flow!");
                }
                nghiThaiSan.StartDate = nghiThaiSanDTO?.StartDate ?? new DateTime();
                nghiThaiSan.WorkflowComments?.Add(new WorkflowComment()
                {
                    UserId = nghiThaiSan.UserCreatedId,
                    Status = CommentStatus.None,
                    Action = WorkflowActionType.MakeChangeWorkflow
                });

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NghiThaiSanFlowDTO LoadNghiThaiSan(int flowId)
        {
            try
            {
                var nghiThaiSanFlow = _context.NghiThaiSanWorkflows.Include(f => f.WorkflowComments).ThenInclude(c => c.User).FirstOrDefault(w => w.Id == flowId);
                var approveCommentList = nghiThaiSanFlow?.WorkflowComments
                        .Where(wc => wc.RegularComment == false)
                        .GroupBy(w => w.UserId)
                        .SelectMany(w => w.OrderByDescending(w => w.TimeStamp).Take(1))
                        .ToList();
                return new NghiThaiSanFlowDTO()
                {
                    FlowId = flowId,
                    UserCreatedId = nghiThaiSanFlow?.UserCreatedId ?? 0,
                    IsHusBand = nghiThaiSanFlow.IsHusband,
                    Status = nghiThaiSanFlow.Status,
                    StartDate = nghiThaiSanFlow.StartDate,

                    Approvers = approveCommentList?.Select(c => new ApproverStatusDTO()
                    {
                        Name = c.User.Name,
                        Status = c.Status
                    }).ToList(),
                    Comments = nghiThaiSanFlow?.WorkflowComments?.OrderBy(wc => wc.TimeStamp).Select(wc => new WorkflowCommentDTO()
                    {
                        Name = wc.User.Name ?? "Người dùng lỗi",
                        TimeStamp = wc.TimeStamp,
                        Text = wc.Action switch
                        {
                            _ when wc.Action == WorkflowActionType.Comment => wc.Comment ?? "Bình luận bị lỗi",
                            _ when wc.Action == WorkflowActionType.MakeChangeWorkflow => "Đã sửa thông tin yêu cầu",
                            _ when wc.Action == WorkflowActionType.NewWorkflow => "Đã được hệ thống thông báo về yêu cầu mới",
                            _ when wc.Action == WorkflowActionType.ApproveWorkflow => "Đã sửa trạng thái bản thân thành \"Đã chấp thuận\"",
                            _ when wc.Action == WorkflowActionType.DenyWorkflow => "Đã sửa trạng thái bản thân thành \"Đã từ chối\"",
                            _ => ""
                        }
                    }).ToList()
                };
            }
            catch
            {
                return new NghiThaiSanFlowDTO();
            }
        }
        public InitialWorkflowDTO LoadInitialNghiThaiSan(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                var nghiThaiSanConfig = _workflowConfigs.NghiThaiSanConfig;
                var listApprovers = GetApproverList(nghiThaiSanConfig.ApproveInfo.CustomApprovers, nghiThaiSanConfig.ApproveInfo.DepartmentIds).Where(a => a != null) ?? new List<User?>();
                return new InitialWorkflowDTO()
                {
                    Approvers = listApprovers.Select(a => new ApproverStatusDTO()
                    {
                        Name = a.Name,
                        Status = CommentStatus.Pending
                    }).ToList()
                };
            }
            catch (Exception)
            {
                return new InitialWorkflowDTO();
            }
        }

        // Check in-out manual
        public void CreateCheckInOutWorkflow(CheckInOutDTO checkInOutDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == checkInOutDTO.UserId);
            var checkInOutWorkflow = new CheckInOutManualWorkflow()
            {
                UserCreatedId = checkInOutDTO.UserId,
                CheckedTime = checkInOutDTO.CheckedTime
            };
            var checkInOutConfig = _workflowConfigs.CheckInOutManualConfig;
            var listApprovers = GetApproverList(checkInOutConfig.ApproveInfo.CustomApprovers, checkInOutConfig.ApproveInfo.DepartmentIds).Where(a => a != null) ?? new List<User?>();

            checkInOutWorkflow.WorkflowComments = listApprovers.Where(x => x != null).Select(a => new WorkflowComment()
            {
                User = a,
                Status = CommentStatus.Pending,
                RegularComment = false,
                Action = WorkflowActionType.NewWorkflow
            }).ToList();

            _context.CheckInOutManualWorkflows.Add(checkInOutWorkflow);
            _context.SaveChanges();
        }
        public CheckInOutFlowDTO LoadCheckInOut(int flowId)
        {
            try
            {
                var checkInOutFlow = _context.CheckInOutManualWorkflows.Include(f => f.WorkflowComments).ThenInclude(c => c.User).FirstOrDefault(w => w.Id == flowId);
                var approveCommentList = checkInOutFlow?.WorkflowComments?
                        .Where(wc => wc.RegularComment == false)
                        .GroupBy(w => w.UserId)
                        .SelectMany(w => w.OrderByDescending(w => w.TimeStamp).Take(1))
                        .ToList();
                return new CheckInOutFlowDTO()
                {
                    FlowId = flowId,
                    UserCreatedId = checkInOutFlow?.UserCreatedId ?? 0,
                    Status = checkInOutFlow.Status,
                    CheckedTime = checkInOutFlow.CheckedTime,

                    Approvers = approveCommentList?.Select(c => new ApproverStatusDTO()
                    {
                        Name = c.User.Name,
                        Status = c.Status
                    }).ToList(),
                    Comments = checkInOutFlow?.WorkflowComments?.OrderBy(wc => wc.TimeStamp).Select(wc => new WorkflowCommentDTO()
                    {
                        Name = wc.User.Name ?? "Người dùng lỗi",
                        TimeStamp = wc.TimeStamp,
                        Text = wc.Action switch
                        {
                            _ when wc.Action == WorkflowActionType.Comment => wc.Comment ?? "Bình luận bị lỗi",
                            _ when wc.Action == WorkflowActionType.MakeChangeWorkflow => "Đã sửa thông tin yêu cầu",
                            _ when wc.Action == WorkflowActionType.NewWorkflow => "Đã được hệ thống thông báo về yêu cầu mới",
                            _ when wc.Action == WorkflowActionType.ApproveWorkflow => "Đã sửa trạng thái bản thân thành \"Đã chấp thuận\"",
                            _ when wc.Action == WorkflowActionType.DenyWorkflow => "Đã sửa trạng thái bản thân thành \"Đã từ chối\"",
                            _ => ""
                        }
                    }).ToList()
                };
            }
            catch
            {
                return new CheckInOutFlowDTO();
            }
        }
        public InitialWorkflowDTO LoadInitialCheckInOut(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                var checkInOutConfig = _workflowConfigs.CheckInOutManualConfig;
                var listApprovers = GetApproverList(checkInOutConfig.ApproveInfo.CustomApprovers, checkInOutConfig.ApproveInfo.DepartmentIds).Where(a => a != null) ?? new List<User?>();
                return new InitialWorkflowDTO()
                {
                    Approvers = listApprovers.Select(a => new ApproverStatusDTO()
                    {
                        Name = a.Name,
                        Status = CommentStatus.Pending
                    }).ToList()
                };
            }
            catch (Exception)
            {
                return new InitialWorkflowDTO();
            }
        }



        /* Some helper methods */

        private IEnumerable<User?> GetApproverList(List<int> userIds, List<int> departmentIds)
        {
            var listUsers = _context.Users.Where(u => userIds.Contains(u.Id)).ToList();
            var listDepartmentLeaders = _context.Departments.Where(d => departmentIds.Contains(d.Id)).Select(d => d.Manager);
            return (listUsers ?? Enumerable.Empty<User>()).Union(listDepartmentLeaders).ToList();
        }

        /*
         * Return configs data and edit configs
         */

        // Return configs data
        public DepartmentAndUserSelectionDTO GetSelections()
        {
            return new DepartmentAndUserSelectionDTO()
            {
                DepartmentSelections = _context.Departments.Select(d => new DropdownSelectionDTO()
                {
                    Id = d.Id,
                    Text = d.Name
                }).ToList(),
                UserSelections = _context.Users.Select(d => new DropdownSelectionDTO()
                {
                    Id = d.Id,
                    Text = d.Name
                }).ToList()
            };
        }

        private List<DropdownSelectionDTO> GetDepartmentInfo(List<int> departmentIds)
        {
            var departmentList = _context.Departments.Where(d => departmentIds.Contains(d.Id));
            return departmentList.Select(d => new DropdownSelectionDTO() { Id = d.Id, Text = d.Name }).ToList();
        }
        private List<DropdownSelectionDTO> GetUserInfo(List<int> userIds)
        {
            var userList = _context.Users.Where(u => userIds.Contains(u.Id));
            return userList.Select(u => new DropdownSelectionDTO() { Id = u.Id, Text = u.Name }).ToList();
        }
    }
}
