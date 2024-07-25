using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        [HttpPost]
        public string UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\a.aldowighri.ext\\TrainStationTracker_angular\\src\\assets\\image", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }
    }
}
