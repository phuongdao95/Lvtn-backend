using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormulaController : ControllerBase
    {
        private readonly IMapper _mapper;
        public FormulaController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
