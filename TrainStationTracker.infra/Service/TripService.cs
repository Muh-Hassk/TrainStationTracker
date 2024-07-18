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
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _tripRepository.SearchTripsBetweenDates(startDate, endDate);
        }
        public async Task CreateTrip(TripsDTO trip)
        {
            await _tripRepository.CreateTrip(trip);
        }

        public async Task DeleteTrip(int id)
        {
            await _tripRepository.DeleteTrip(id);
        }

        public async Task<List<Trip>> GetAllTrips()
        {
          return  await _tripRepository.GetAllTrips();
        }
        public async Task<List<Trip>> GetTripsByOriginStation(int id)
        {
            return await _tripRepository.GetTripsByOriginStation(id);
        }
        public async Task<List<Trip>> GetTripsByOriginAndDest(int originId, int destId)
        {
            return await _tripRepository.GetTripsByOriginAndDest(originId, destId);
        }


        public async Task<Trip> GetTripById(int id)
        {
           return await _tripRepository.GetTripById(id);  
        }

        public async Task UpdateTrip(TripsDTO trip)
        {
            await _tripRepository.UpdateTrip(trip);
        }
    }
}
