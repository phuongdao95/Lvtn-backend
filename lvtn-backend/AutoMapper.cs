using AutoMapper;
using Models.Models;
using lvtn_backend.DTO.Request;
using lvtn_backend.DTO.Response;

namespace lvtn_backend
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // Map from requests to internal entities
            CreateMap<UserDTO, User>();

            CreateMap<TeamDTO, Team>();

            //Map from internal entities to responses
            CreateMap<User, UserInfoDTO>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.Sex, opt => opt.MapFrom(src => src.Sex == true ? "Male" : "Female"))
                .ForMember(des => des.TeamName, opt => opt.MapFrom(src => src.TeamBelong != null ? src.TeamBelong.Name : ""));
        }
    }
}
