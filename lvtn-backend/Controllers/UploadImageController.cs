using lvtn_backend.DTO.Request;
using lvtn_backend.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        // get local path
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadImageController(IWebHostEnvironment webHostEnvironment)
        {
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
                var t = img.ImageData.Substring(31); // remove data:image/png;base64,
                byte[] bytes = Convert.FromBase64String(t);
                // save image
                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }
                var fileName = img.ImageName + ".png";
                // local path
                string localPath = _webHostEnvironment.ContentRootPath;
                // folder for training image
                System.IO.Directory.CreateDirectory(localPath + "/Images/Training/");
                var fullPath = Path.Combine(localPath + "/Images/Training/", fileName);
                //var fullPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
