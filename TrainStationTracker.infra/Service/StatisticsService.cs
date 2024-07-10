using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.infra.Service
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsService (IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public int GetNumberOfBookedTrips()
        {
            return _statisticsRepository.GetNumberOfBookedTrips();
        }

        public int GetNumberOfTrainStations()
        {
            return _statisticsRepository.GetNumberOfTrainStations();
        }

        public int GetNumberOfTrips()
        {
           return _statisticsRepository.GetNumberOfTrips();
        }

        public int GetNumberOfUsers()
        {
            return _statisticsRepository.GetNumberOfUsers();
        }
        public int GetTotalPrice()
        {
            return _statisticsRepository.GetTotalPrice();
        }
    }
}
