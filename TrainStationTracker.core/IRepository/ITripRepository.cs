using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IRepository
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAllTrips();
        Task<Trip> GetTripById(int id);
        Task<List<Trip>> GetTripsByOriginStation(int id);
        Task<List<Trip>> GetTripsByOriginAndDest(int originId, int destId);
        Task CreateTrip(TripsDTO trip);
        Task UpdateTrip(TripsDTO trip);
        Task DeleteTrip(int id);
        List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate);
        Task<List<Trip>> GetTripsByDestination(int id);

    }
}
