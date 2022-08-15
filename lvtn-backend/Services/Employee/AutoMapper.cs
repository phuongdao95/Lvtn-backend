
using AutoMapper;
using lvtn_backend.Models;
using lvtn_backend.ViewModels;

namespace lvtn_backend.Services.EmployeeService
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
