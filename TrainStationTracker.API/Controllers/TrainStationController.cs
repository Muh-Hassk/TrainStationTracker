﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.Data;
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
        [CheckClaims("RoleId", "1")]
        public Task<List<Trainstation>> GetAllTrainStations()
        {
            return _trainStationService.GetAllTrainStations();
        }
    }
}
