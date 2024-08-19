using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;
using TrainStationTracker.infra.Service;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public Task<List<Testimonial>> GetAllTestimonial()
        {
            return _testimonialService.GetAllTestimonial();
        }

        [HttpGet]
        public Task<List<Testimonial>> GetAllApprovedTestimonial()
        {
            return _testimonialService.GetAllApprovedTestimonial();
        }



        [HttpPut("{id}")] // hostname/port/api/course/1
        public async Task AcceptTestimonial(int id)
        {
            await _testimonialService.AcceptTestimonial(id);
        }
        [HttpPut("{id}")] // hostname/port/api/course/1
        public async Task RejectTestimonial(int id)
        {
            await _testimonialService.RejectTestimonial(id);
        }

        [HttpPost]
       // [CheckClaims("RoleId", "1")]
        public async Task<IActionResult> WriteTestimonial([FromBody] TestimonialDTO testimonial)
        {
            var userIdString = User.FindFirst("Userid")?.Value;

            if (userIdString == null)
            {
                return Unauthorized("User ID not found in JWT token");
            }

            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID format");
            }

            try
            {
                testimonial.Userid = userId;
                await _testimonialService.WriteTestimonial(testimonial);
                return Ok("Testimonial Added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

