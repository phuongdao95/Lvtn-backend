using lvtn_backend.DTO.Request;
using lvtn_backend.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace lvtn_backend.Controllers
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

        [HttpPost("")]
        public IActionResult UploadImage(UploadImageDTO img)
        {
            try
            {
                if (string.IsNullOrEmpty(img.ImageData))
                {
                    return BadRequest("not image data");
                }
                
                // local path
                string localPath = _webHostEnvironment.ContentRootPath;
                // folder for training image
                _aiService.UploadImage(img.ImageName, img.ImageData, localPath);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
