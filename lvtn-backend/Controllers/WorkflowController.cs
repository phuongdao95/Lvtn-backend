using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.DTO.WorkflowConfigs;
using Models.Models;
using Services.Contracts;
using System.Text.Json;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly string ConfigPath = @"../Models/DTO/WorkflowConfigs/workflowconfigs.json";
        private readonly IWorkflowService _workflowService;
        private readonly IMapper _mapper;
        public WorkflowController(IWorkflowService workflowService, IMapper mapper)
        {
            _workflowService = workflowService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllConfig()
        {
            using (var r = new StreamReader(ConfigPath))
            {
                string json = r.ReadToEnd();
                return Ok(JsonSerializer.Deserialize<WorkflowConfigs>(json));
            }
        }

        [HttpGet("requests/{userId}")]
        public IActionResult GetAllRequestsByUserId(int userId)
        {
            var requestList = _workflowService.GetWorkflowRequestsByUserId(userId);
            return Ok(_mapper.Map<IEnumerable<Workflow>, IEnumerable<WorkflowInformationDTO>>(requestList));
        }

        [HttpPost("nghi-phep-config")]
        public IActionResult EditNghiPhepConfig(NghiPhepConfig nghiPhepConfig)
        {
            WorkflowConfigs workflowConfigs = new WorkflowConfigs();
            using (var r = new StreamReader("../Models/DTO/WorkflowConfigs/workflowconfigs.json"))
            {
                string jsonIn = r.ReadToEnd();
                workflowConfigs = JsonSerializer.Deserialize<WorkflowConfigs>(jsonIn)!;
            }
            
            if (workflowConfigs == null)
            {
                return NotFound("Cannot find config file!");
            }

            workflowConfigs.NghiPhepConfig = nghiPhepConfig;
            
            using (var f = new FileStream(ConfigPath, FileMode.Create))
            {
                JsonSerializer.Serialize(f, workflowConfigs, new JsonSerializerOptions() { WriteIndented = true });
            }
            return Ok();
        }

        [HttpPost("nghi-thai-san-config")]
        public IActionResult EditNghiThaiSanConfig(NghiThaiSanConfig nghiThaiSanConfig)
        {
            WorkflowConfigs workflowConfigs = new WorkflowConfigs();
            using (var r = new StreamReader("../Models/DTO/WorkflowConfigs/workflowconfigs.json"))
            {
                string jsonIn = r.ReadToEnd();
                workflowConfigs = JsonSerializer.Deserialize<WorkflowConfigs>(jsonIn)!;
            }

            if (workflowConfigs == null)
            {
                return NotFound("Cannot find config file!");
            }

            workflowConfigs.NghiThaiSanConfig = nghiThaiSanConfig;

            using (var f = new FileStream(ConfigPath, FileMode.Create))
            {
                JsonSerializer.Serialize(f, workflowConfigs, new JsonSerializerOptions() { WriteIndented = true });
            }
            return Ok();
        }

        /*
         ** Nghi phep workflow
         */
        [HttpPost("nghi-phep")]
        public IActionResult CreateNghiPhep(NghiPhepDTO nghiPhepDTO)
        {
            _workflowService.CreateNghiPhepWorkflow(nghiPhepDTO);
            return Ok();
        }


        [HttpPost("comment")]
        public IActionResult PostComment(WorkflowUserCommentDTO comment)
        {
            _workflowService.AddComment(comment);
            return Ok();
        }
    }
}
