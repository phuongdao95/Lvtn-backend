using Models.DTO.Request;
using Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private IAiService _aiService;
        // get local path
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadImageController(IAiService aiService, 
            IWebHostEnvironment webHostEnvironment)
        {
            _aiService = aiService;
            _webHostEnvironment = webHostEnvironment;
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
