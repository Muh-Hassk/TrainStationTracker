using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet]
        public int GetNumberOfBookedTrips()
        {
            return _statisticsService.GetNumberOfBookedTrips();
        }
        [HttpGet]
        public int GetNumberOfTrainStations()
        {
            return _statisticsService.GetNumberOfTrainStations();
        }
        [HttpGet]
        public int GetNumberOfTrips()
        {
            return _statisticsService.GetNumberOfTrips();
        }
        [HttpGet]
        public int GetNumberOfUsers()
        {
            return _statisticsService.GetNumberOfUsers();
        }
        [HttpGet]
        public int GetTotalPrice()
        {
            return _statisticsService.GetTotalPrice();
        }
    }
}
