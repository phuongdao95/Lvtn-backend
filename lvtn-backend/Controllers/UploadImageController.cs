using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Services;

namespace Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private IAiService _aiService;
        private WorkingShiftTimekeepingService _workingShiftTimekeepingService;
        private WorkingShiftTimekeepingHistoryService _workingShiftTimekeepingHistoryService;
        // get local path
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadImageController(IAiService aiService, IWebHostEnvironment webHostEnvironment, 
            WorkingShiftTimekeepingService workingShiftTimekeepingService,
            WorkingShiftTimekeepingHistoryService workingShiftTimekeepingHistoryService)
        {
            _aiService = aiService;
            _webHostEnvironment = webHostEnvironment;
            _workingShiftTimekeepingService = workingShiftTimekeepingService;
            _workingShiftTimekeepingHistoryService = workingShiftTimekeepingHistoryService;
        }

        // upload image
        [HttpPost("")]
        public IActionResult UploadImage(UploadImageDTO img)
        {
            try
            {
                // local path
                string localPath = _webHostEnvironment.ContentRootPath;
                bool result = _aiService.UploadImage(img.ImageName, img.ImageData, localPath);
                if (result)
                {
                    if (img.dto.DidCheckout)
                    {
                        _workingShiftTimekeepingService.Update(img.dto.Id, img.dto);
                        WorkingShiftTimekeepingHistoryDTO obj = new WorkingShiftTimekeepingHistoryDTO();
                        //obj.Id = img.dto.Id;
                        obj.IsCheckIn = false;
                        obj.DateTime = (DateTime)(img.dto.CheckoutTime);
                        obj.TimekeepingId = img.dto.Id;
                        _workingShiftTimekeepingHistoryService.Add(obj);
                    }
                    else
                    {
                        _workingShiftTimekeepingService.Add(img.dto);

                        WorkingShiftTimekeepingHistoryDTO obj = new WorkingShiftTimekeepingHistoryDTO();
                        obj.IsCheckIn = true;
                        obj.DateTime = (DateTime)(img.dto.CheckinTime);
                        obj.TimekeepingId = img.dto.Id;
                        _workingShiftTimekeepingHistoryService.Add(obj);
                    }
                    return Ok(img.ImageName);
                }
                else
                {
                    return Ok("not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // register image
        [HttpPost("Register")]
        public IActionResult RegisterImage(UploadImageDTO img)
        {
            try
            {
                // local path
                string localPath = _webHostEnvironment.ContentRootPath;
                // folder for training image
                bool result = _aiService.RegisterImage(img.ImageName, img.ImageData, localPath);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
