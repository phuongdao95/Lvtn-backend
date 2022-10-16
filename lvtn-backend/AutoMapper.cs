using AutoMapper;
using Models.Models;
using Models.DTO.Request;
using Models.DTO.Response;
using Group = Models.Models.Group;

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

            CreateMap<Department, DepartmentInfoDTO>();

            CreateMap<SalaryDelta, SalaryDeltaInfoDTO>();

            CreateMap<SalaryFormula, SalaryFormulaInfoDTO>();

            CreateMap<SalaryVariable, SalaryVariableInfoDTO>();

            CreateMap<Payroll, PayrollInfoDTO>();

            CreateMap<Payslip, PayslipInfoDTO>()
                .ForMember(m => m.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(m => m.PayrollName, opt => opt.MapFrom(src => src.Payroll.Name))
                ;

            CreateMap<SalaryGroup, SalaryGroupInfoDTO>()
                .ForMember(m => m.GroupName, opt => opt.MapFrom(src => src.Group.Name))
                .ForMember(m => m.GroupId, opt => opt.MapFrom(src => src.GroupId))
                ;
        }
    }
}
