using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [CheckClaims("RoleId", "2")]
        public async Task<IActionResult> BookTrip([FromBody] BookTicket ticket)
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
                ticket.Userid = userId;
                await _bookingService.BookTrip(ticket);
                return Ok("Trip booked successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<List<UserBookings>> GetUserBookings(int id)
        {
            return await _bookingService.GetUserBookings(id);
        }
    }
}