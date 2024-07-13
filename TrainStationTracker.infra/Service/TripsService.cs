using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.infra.Service
{
    public class TripsService : ITripsService
    {
        private readonly ITripsRepository _Trips;
        public TripsService(ITripsRepository Trips)
        {
            _Trips = Trips;
        }

        public List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _Trips.SearchTripsBetweenDates(startDate, endDate);
        }
    }
}
