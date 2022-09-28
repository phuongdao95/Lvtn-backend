using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    public class SalaryDeltaController : ControllerBase
    {
        private readonly IMapper _mapper;
        public SalaryDeltaController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
