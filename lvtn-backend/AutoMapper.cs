using AutoMapper;
using Models.Models;
using Models.DTO.Request;
using Models.DTO.Response;

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

            CreateMap<GroupDTO, Group>();

            //Map from internal entities to responses
            CreateMap<User, UserInfoDTO>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.Sex, opt => opt.MapFrom(src => src.Sex == true ? "Nam" : "Nữ"))
                .ForMember(des => des.TeamName, opt => opt.MapFrom(src => src.TeamBelong != null ? src.TeamBelong.Name : ""));

            CreateMap<Team, TeamInfoDTO>()
                .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Detail))
                .ForMember(des => des.LeaderName, opt => opt.MapFrom(src => src.Leader != null ?
                    src.Leader.Name : "None"))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department != null ?
                    src.Department.Name : "None"));

            CreateMap<Role, RoleInfoDTO>();

            CreateMap<GroupInfoDTO, Group>();

            CreateMap<Department, DepartmentInfoDTO>();

            CreateMap<SalaryDelta, SalaryDeltaInfoDTO>();

            CreateMap<SalaryFormula, SalaryFormulaInfoDTO>();

            CreateMap<SalaryVariable, SalaryVariableInfoDTO>();

            CreateMap<Payroll, PayrollInfoDTO>();

            CreateMap<Payslip, PayslipInfoDTO>()
                .ForMember(m => m.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(m => m.PayrollName, opt => opt.MapFrom(src => src.Payroll.Name))
                ;

            CreateMap<Group, GroupInfoDTO>();

            CreateMap<Workflow, WorkflowInformationDTO>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src is NghiPhepWorkflow ? "Nghi phep" : "Not nghi phep"))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.TimeStamp.ToShortDateString()))
                .ForMember(des => des.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
