using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.DTO.WorkflowConfigs;
using Models.Enums;
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
        private readonly WorkflowConfigs _workflowConfigs;
        public WorkflowController(IWorkflowService workflowService, IMapper mapper)
        {
            _workflowService = workflowService;
            _mapper = mapper;
            _workflowConfigs = new WorkflowConfigs();
            using (var r = new StreamReader("../Models/DTO/WorkflowConfigs/workflowconfigs.json"))
            {
                string jsonIn = r.ReadToEnd();
                _workflowConfigs = JsonSerializer.Deserialize<WorkflowConfigs>(jsonIn)!;
            }
        }

        /*
         * General tasks
         */

        [HttpGet("requests/{userId}")]
        public IActionResult GetAllRequestsByUserId(int userId)
        {
            var requestList = _workflowService.GetWorkflowRequestsByUserId(userId);
            return Ok(_mapper.Map<IEnumerable<Workflow>, IEnumerable<WorkflowInformationDTO>>(requestList));
        }

        [HttpGet("flows/{userId}")]
        public IActionResult GetAllRequestsByApproverId(int userId)
        {
            var requestList = _workflowService.GetWorkflowRequestsByApproverId(userId);
            var response = _mapper.Map<IEnumerable<Workflow>, IEnumerable<WorkflowInformationDTO>>(requestList);
            foreach (var item in response)
            {
                var commentList = requestList?
                                    .FirstOrDefault(w => w.Id == item.Id)?
                                    .WorkflowComments?.Where(c => c.UserId == userId)?
                                    .Where(c => c.Status != CommentStatus.None);
                var lastSpecialComment = commentList?.OrderByDescending(c => c.TimeStamp).FirstOrDefault();
                item.ApproverStatus = (int)lastSpecialComment?.Status;
            }
            return Ok(response);
        }

        [HttpGet("request/approve/selection-list")]
        public IActionResult GetSelectionList()
        {
            return Ok(_workflowService.GetSelections());
        }

        [HttpPost("workflow/{userId}/{flowId}/set-status")]
        public IActionResult SetApproverStatusForFlow(int userId, int flowId, CommentStatus status)
        {
            try
            {
                _workflowService.UpdateWorkflowStatus(new WorkflowApproverUpdateDTO()
                {
                    ApproverId = userId,
                    Status = status,
                    WorkflowId = flowId
                });
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        /*
         * Get and edit workflow configs
         */
        // Nghi phep

        [HttpPost("nghi-phep-config")]
        public IActionResult EditNghiPhepConfig(NghiPhepConfig nghiPhepConfig)
        {
            _workflowConfigs.NghiPhepConfig = nghiPhepConfig;
            
            using (var f = new FileStream(ConfigPath, FileMode.Create))
            {
                JsonSerializer.Serialize(f, _workflowConfigs, new JsonSerializerOptions() { WriteIndented = true });
            }
            return Ok();
        }

        [HttpGet("nghi-phep-config")]
        public IActionResult GetNghiPhepConfig()
        {
            return Ok(_workflowConfigs.NghiPhepConfig);
        }

        // Nghi thai san

        [HttpPost("nghi-thai-san-config")]
        public IActionResult EditNghiThaiSanConfig(NghiThaiSanConfig nghiThaiSanConfig)
        {
            _workflowConfigs.NghiThaiSanConfig = nghiThaiSanConfig;

            using (var f = new FileStream(ConfigPath, FileMode.Create))
            {
                JsonSerializer.Serialize(f, _workflowConfigs, new JsonSerializerOptions() { WriteIndented = true });
            }
            return Ok();
        }

        [HttpGet("nghi-thai-san-config")]
        public IActionResult GetNghiThaiSanConfig()
        {
            return Ok(_workflowConfigs.NghiThaiSanConfig);
        }

        // Check inout manual

        [HttpPost("checkinout-config")]
        public IActionResult EditCheckInOutConfig(CheckInOutManualConfig checkInOutManualConfig)
        {
            _workflowConfigs.CheckInOutManualConfig = checkInOutManualConfig;

            using (var f = new FileStream(ConfigPath, FileMode.Create))
            {
                JsonSerializer.Serialize(f, _workflowConfigs, new JsonSerializerOptions() { WriteIndented = true });
            }
            return Ok();
        }

        [HttpGet("checkinout-config")]
        public IActionResult GetCheckInOutConfig()
        {
            return Ok(_workflowConfigs.CheckInOutManualConfig);
        }


        /*
         * Nghi phep workflow -> Create and Edit
         */

        [HttpPost("nghi-phep")]
        public IActionResult CreateNghiPhep(NghiPhepDTO nghiPhepDTO)
        {
            _workflowService.CreateNghiPhepWorkflow(nghiPhepDTO);
            return Ok();
        }
        [HttpPut("nghi-phep")]
        public IActionResult EditNghiPhep(NghiPhepDTO nghiPhepDTO)
        {
            _workflowService.UpdateNghiPhepWorkflow(nghiPhepDTO);
            return Ok();
        }
        [HttpGet("initial-nghi-phep/{userId}")]
        public IActionResult InitialNghiPhep(int userId)
        {
            return Ok(_workflowService.LoadInitialNghiPhep(userId));
        }
        [HttpGet("workflow/nghi-phep/{id}")]
        public IActionResult GetNghiPhepFlows(int id)
        {
            return Ok(_workflowService.LoadNghiPhep(id));
        }

        /*
         * Nghi thai san workflow -> Create and Edit
         */
        [HttpPost("nghi-thai-san")]
        public IActionResult CreateNghiThaiSan(NghiThaiSanDTO nghiThaiSanDTO)
        {
            _workflowService.CreateNghiThaiSanWorkflow(nghiThaiSanDTO);
            return Ok();
        }
        [HttpPut("nghi-thai-san")]
        public IActionResult EditNghiThaiSan(NghiThaiSanDTO nghiThaiSanDTO)
        {
            _workflowService.UpdateNghiThaiSanWorkflow(nghiThaiSanDTO);
            return Ok();
        }
        [HttpGet("initial-nghi-thai-san/{userId}")]
        public IActionResult InitialNghiThaiSan(int userId)
        {
            return Ok(_workflowService.LoadInitialNghiThaiSan(userId));
        }
        [HttpGet("workflow/nghi-thai-san/{id}")]
        public IActionResult GetNghiThaiSanFlows(int id)
        {
            return Ok(_workflowService.LoadNghiThaiSan(id));
        }

        /*
         * Diem danh workflow -> Create and Edit
         */
        [HttpPost("check-in-out")]
        public IActionResult CreateCheckInOut(CheckInOutDTO checkInOutDTO)
        {
            _workflowService.CreateCheckInOutWorkflow(checkInOutDTO);
            return Ok();
        }
        [HttpGet("initial-check-in-out/{userId}")]
        public IActionResult InitialCheckInOut(int userId)
        {
            return Ok(_workflowService.LoadInitialCheckInOut(userId));
        }
        [HttpGet("workflow/check-in-out/{id}")]
        public IActionResult GetNghiCheckInOutFlows(int id)
        {
            return Ok(_workflowService.LoadCheckInOut(id));
        }

        /*
         * Comment on workflow and update workflow status
         */
        [HttpPost("comment")]
        public IActionResult PostComment(WorkflowUserCommentDTO comment)
        {
            _workflowService.AddComment(comment);
            return Ok();
        }
    }
}
