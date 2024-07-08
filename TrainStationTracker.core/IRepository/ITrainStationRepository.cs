using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;

namespace TrainStationTracker.core.IRepository
{
    public interface ITrainStationRepository
    {
        public Task<List<Trainstation>> GetAllTrainStations();

    }
}
