using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}")]
        public async Task<Trainstation> GetTrainstationById(int id)
        {
            return await _trainStationService.GetTrainstationById(id);
        }
        [HttpPost]
        //[CheckClaims("RoleId", "1")]
        public async Task CreateTrainstation(Trainstation trainstation)
        {
            await _trainStationService.CreateTrainstation(trainstation);
        }
        [HttpPut]
        //[CheckClaims("RoleId", "1")]
        public async Task UpdateTrainstation(UpdateTrainstation trainstation)
        {
            await _trainStationService.UpdateTrainstation(trainstation);
        }
        [HttpDelete("{id}")]
        //[CheckClaims("RoleId", "1")]
        public async Task DeleteTrainstation(int id)
        {
            await _trainStationService.DeleteTrainstation(id);
        }

    }

}