using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IService
{
    public interface ITripsService
    {
        List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate);

    }
}
