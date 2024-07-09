using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.infra.Service
{
    public class TrainStationService : ITrainStationService
    {
        private readonly ITrainStationRepository _trainStationRepository;
        public TrainStationService(ITrainStationRepository trainStationRepository)
        {
            _trainStationRepository = trainStationRepository;
        }
        public Task<List<Trainstation>> GetAllTrainStations()
        {
           var res = _trainStationRepository.GetAllTrainStations();
            
            return _trainStationRepository.GetAllTrainStations();
        }

        public  Task<List<Trainstation>> GetTrainStationByName(Name name)
        {
            var res =  _trainStationRepository.GetTrainStationByName(name);

            return _trainStationRepository.GetTrainStationByName(name);
        }

    }
}

