using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IRepository;

namespace TrainStationTracker.core.IService
{
    public interface ITrainStationService
    {
        public Task<List<Trainstation>> GetAllTrainStations();


        public Task<List<Trainstation>> GetTrainStationByName(Name name);
        Task<Trainstation> GetTrainstationById(int id);
        Task CreateTrainstation(Trainstation trainstation);
        Task UpdateTrainstation(UpdateTrainstation trainstation);
        Task DeleteTrainstation(int id);

    }
}
