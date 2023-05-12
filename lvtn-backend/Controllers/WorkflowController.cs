using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.DTO.Workflow.Request;
using Models.DTO.WorkflowConfigs;
using Models.Enums;
using Models.Models;
using Services.Contracts;
using Services.Services;
using System.Text.Json;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;
        private readonly IMapper _mapper;
        public WorkflowController(IWorkflowService workflowService, IMapper mapper)
        {
            _workflowService = workflowService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateNewWorkflowDefine(NewWorkflowDefine dto)
        {
            return Ok(_workflowService.DefineNewWorkflow(_mapper.Map<WorkflowDefine>(dto), dto.DefaultAssignUsers, dto.WorkflowTypeNames));
        }
    }
}
