using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Response;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        private readonly IMapper _mapper;
        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _mapper = mapper;
            _permissionService = permissionService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPermissionById(int id)
        {
            try
            {
                var permission = _permissionService.GetPermissionById(id);

                var permissionInfo = _mapper.Map<PermissionInfoDTO>(permission);

                return Ok(permissionInfo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetPermissionList()
        {
            try
            {
                var permissionList = _permissionService.GetAllPermissions();

                var permissionInfoList = _mapper.Map<IEnumerable<PermissionInfoDTO>>(permissionList);

                var count = _permissionService.GetAllPermissionCount();

                var result = new Dictionary<string, object>
                {
                    {"data", permissionInfoList },
                    {"count", permissionInfoList.Count()},
                    {"total", count }
                };

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
