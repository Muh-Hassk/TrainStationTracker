using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TrainStationTracker.core.Data;

using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripsController : ControllerBase
    {

        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpPost]
        //[CheckClaims("RoleId", "1")]
        public async Task CreateTrip(TripsDTO trip)
        {
            await _tripService.CreateTrip(trip);
        }
        [HttpDelete("{id}")]
        public async Task DeleteTrip(int id)
        {
            await _tripService.DeleteTrip(id);
        }
        [HttpGet]
        public async Task<List<Trip>> GetAllTrips()
        {
            return await _tripService.GetAllTrips();
        }
        [HttpGet]
        public async Task<List<Trip>> GetTripsByOriginAndDest(int originId, int destId)
        {
            return await _tripService.GetTripsByOriginAndDest(originId, destId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<List<Trip>> GetTripsByOriginStation(int id)
        {
            return await _tripService.GetTripsByOriginStation(id);
        }
        [HttpGet("{id}")]
        public async Task<Trip> GetTripById(int id)
        {
            return await _tripService.GetTripById(id);
        }
        [HttpPut]
        //[CheckClaims("RoleId", "1")]
        public async Task UpdateTrip(TripsDTO trip)
        {
            await _tripService.UpdateTrip(trip);
        }
        [HttpGet]
        [Route("{startDate}/{endDate}")]

        public List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _tripService.SearchTripsBetweenDates(startDate, endDate);

        }
        [HttpGet("{id}")]
        public async Task<List<Trip>> GetTripsByDestination(int id)
        {
            return await _tripService.GetTripsByDestination(id);
        }
    }
}
