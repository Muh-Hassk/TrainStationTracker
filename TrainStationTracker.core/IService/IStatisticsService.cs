using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.IService
{
    public interface IStatisticsService
    {
        int GetNumberOfUsers();

        int GetNumberOfTrainStations();

        int GetNumberOfTrips();

        int GetNumberOfBookedTrips();

        int GetTotalPrice();
    }
}
