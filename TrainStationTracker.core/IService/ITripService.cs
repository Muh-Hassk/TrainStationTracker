﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IService
{
    public interface ITripService
    {
        Task<List<Trip>> GetAllTrips();
        Task<Trip> GetTripById(int id);
        Task<List<Trip>> GetTripsByOriginAndDest(int originId, int destId);
        Task<List<Trip>> GetTripsByOriginStation(int id);
        Task CreateTrip(TripsDTO trip);
        Task UpdateTrip(TripsDTO trip);
        Task DeleteTrip(int id);
        List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate);
        Task<Trip> GetTripsByDestination(int id);

    }
}
