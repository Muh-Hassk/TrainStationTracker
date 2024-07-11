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

        public async Task CreateTrainstation(Trainstation trainstation)
        {
            await _trainStationRepository.CreateTrainstation(trainstation);
        }

        public async Task DeleteTrainstation(int id)
        {
            await _trainStationRepository.DeleteTrainstation(id);
        }

        public Task<List<Trainstation>> GetAllTrainStations()
        {
           var res = _trainStationRepository.GetAllTrainStations();
            
            return _trainStationRepository.GetAllTrainStations();
        }

        public async Task<Trainstation> GetTrainstationById(int id)
        {
            return await _trainStationRepository.GetTrainstationById(id);
        }

        public  Task<List<Trainstation>> GetTrainStationByName(Name name)
        {
            var res =  _trainStationRepository.GetTrainStationByName(name);

            return _trainStationRepository.GetTrainStationByName(name);
        }

        public async Task UpdateTrainstation(UpdateTrainstation trainstation)
        {
            await _trainStationRepository.UpdateTrainstation(trainstation);
        }
    }
}

