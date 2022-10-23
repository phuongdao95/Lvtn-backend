using AutoMapper;
using Models.Models;
using Models.DTO.Request;
using Models.DTO.Response;
using Group = Models.Models.Group;
using Task = Models.Models.Task;

namespace Models
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // Map from requests to internal entities
            CreateMap<UserDTO, User>();

            CreateMap<TeamDTO, Team>();

            CreateMap<RoleDTO, Role>();

            CreateMap<GroupDTO, Group>();

            CreateMap<DepartmentDTO, Department>();

            CreateMap<SalaryDeltaDTO, SalaryDelta>();

            CreateMap<SalaryFormulaDTO, SalaryFormula>();

            CreateMap<SalaryVariableDTO, SalaryVariable>();

            CreateMap<PayrollDTO, Payroll>();

            CreateMap<SalaryGroupDTO, SalaryGroup>();

            CreateMap<TaskDTO, Task>();

            CreateMap<TaskBoardDTO, TaskBoard>();

            CreateMap<TaskLabelDTO, TaskLabel>();

            CreateMap<TaskColumnDTO, TaskColumn>();

            CreateMap<TaskFile, TaskFileDTO>();

            CreateMap<TaskCommentDTO, TaskComment>();

            //Map from internal entities to responses
            CreateMap<User, UserInfoDTO>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.TeamName, opt => opt.MapFrom(src => src.Team != null ? src.Team.Name : "None"))
                .ForMember(des => des.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : "None"));

            CreateMap<Team, TeamInfoDTO>()
                .ForMember(des => des.MemberIds, opt => opt.MapFrom(src => src.Members.Select(member => member.Id)))
                .ForMember(des => des.MemberNames, opt => opt.MapFrom(src => src.Members.Select(member => member.Name)))
                .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Detail))
                .ForMember(des => des.LeaderName, opt => opt.MapFrom(src => src.Leader != null ?
                    src.Leader.Name : "None"))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department != null ?
                    src.Department.Name : "None"));


            CreateMap<Role, RoleInfoDTO>();

            CreateMap<Permission, PermissionInfoDTO>();

            CreateMap<Group, GroupInfoDTO>();

            CreateMap<Department, DepartmentInfoDTO>()
                .ForMember(p => p.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
                .ForMember(p => p.ManagerName, opt => opt.MapFrom(dest => dest.Manager.Name))
                .ForMember(p => p.ParentDepartmentId, opt => opt.MapFrom(src => src.ParentDepartment.Id))
                .ForMember(p => p.ParentDepartmentName, opt => opt.MapFrom(src => src.ParentDepartment.Name));

            CreateMap<SalaryDelta, SalaryDeltaInfoDTO>();

            CreateMap<SalaryFormula, SalaryFormulaInfoDTO>();

            CreateMap<SalaryVariable, SalaryVariableInfoDTO>();

            CreateMap<Payroll, PayrollInfoDTO>();

            CreateMap<Payslip, PayslipInfoDTO>()
                .ForMember(m => m.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(m => m.PayrollName, opt => opt.MapFrom(src => src.Payroll.Name))
                ;

            CreateMap<PayslipWorkingShiftTimekeeping, PayslipTimekeepingInfoDTO>();

            CreateMap<PayslipSalaryDelta, PayslipSalaryDeltaInfoDTO>();

            CreateMap<SalaryGroup, SalaryGroupInfoDTO>()
                .ForMember(m => m.GroupName, opt => opt.MapFrom(src => src.Group.Name))
                ;

            CreateMap<TaskBoard, TaskBoardInfoDTO>()
                .ForMember(m => m.TeamName, opt => opt.MapFrom(src => src.Team.Name));

            CreateMap<TaskLabel, TaskLabelInfoDTO>()
                .ForMember(m => m.TaskBoardName, opt => opt.MapFrom(src => src.TaskBoard.Name));

            CreateMap<TaskColumn, TaskColumnInfoDTO>()
                .ForMember(m => m.BoardName, opt => opt.MapFrom(src => src.Board.Name));

            CreateMap<Task, TaskInfoDTO>()
                .ForMember(m => m.ColumnName, opt => opt.MapFrom(src => src.Column.Name))
                .ForMember(m => m.ReportToName, opt => opt.MapFrom(src => src.ReportTo != null ? src.ReportTo.Name : "Unassigned"))
                .ForMember(m => m.InChargeName, opt => opt.MapFrom(src => src.InCharge != null ? src.InCharge.Name : "Unassigned"));

            CreateMap<TaskFile, TaskFileInfoDTO>()
                .ForMember(m => m.DisplayName, opt => opt.MapFrom(src => src.DisplayFileName))
                .ForMember(m => m.Path, opt => opt.MapFrom(src => $"/taskfile/{src.Id}"));

            CreateMap<TaskComment, TaskCommentInfoDTO>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(src => src.User.Name));
        }

    }
}
