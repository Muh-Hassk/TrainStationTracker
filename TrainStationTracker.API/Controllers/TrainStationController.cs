using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrainStationController : ControllerBase
    {
        private readonly ITrainStationService _trainStationService;

        public TrainStationController(ITrainStationService trainStationService)
        {
            _trainStationService = trainStationService;
        }

        [HttpGet]
        public Task<List<Trainstation>> GetAllTrainStations()
        {
            return _trainStationService.GetAllTrainStations();
        }

        [HttpPost]
        public async Task<List<Trainstation>> GetTrainStationByName([FromBody] Name name)
        {
            return await _trainStationService.GetTrainStationByName(name);
        }

    }

}