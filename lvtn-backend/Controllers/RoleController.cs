using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper, IPermissionService permissionService)
        {
            _roleService = roleService;
            _mapper = mapper;
            _permissionService = permissionService;
        }

        [HttpGet("{roleId}")]
        public IActionResult GetRoleById(int roleId)
        {
            try
            {
                var role = _roleService.GetRoleById(roleId);
                var roleInfo = _mapper.Map<RoleInfoDTO>(role);
                return Ok(roleInfo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetRoleList(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 20,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name")
        {
            try
            {
                var roleList = _roleService.GetRoleList(offset, limit, query, queryType);
                var roleInfo = _mapper.Map<IEnumerable<RoleInfoDTO>>(roleList);
                var result = new Dictionary<string, object>();
                result.Add("data", roleInfo);
                result.Add("count", roleInfo.Count());
                result.Add("total", _roleService.GetRoleCount());

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoleById(int id, RoleDTO roleDTO)
        {
            try
            {
                _roleService.UpdateRole(id, roleDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateRole(RoleDTO roleDTO)
        {
            try
            {
                _roleService.AddRole(roleDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoleById(int id)
        {
            try
            {
                _roleService.DeleteRoleById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/permission")]
        public IActionResult GetPermissionOfRole(int id)
        {
            try
            {
                var permission = _permissionService.GetPermissionsOfRole(id);
                var mapped = _mapper.Map<IEnumerable<PermissionInfoDTO>>(permission);
                return Ok(new Dictionary<string, object>
                {
                    {"data", mapped },
                    {"count", mapped.Count() },
                    {"total", mapped.Count() }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
