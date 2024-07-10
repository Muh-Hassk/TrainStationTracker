using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;
        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }
        [HttpGet]
        [Route("{startDate}/{endDate}")]
        public List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _tripsService.SearchTripsBetweenDates(startDate, endDate);
        }
    }
}
