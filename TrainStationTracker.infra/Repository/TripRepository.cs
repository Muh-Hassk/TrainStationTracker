﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;

namespace TrainStationTracker.infra.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly IDbContext _dbContext;

        public TripRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTrip(TripsDTO trip)
        {
            trip.Createdat = DateTime.Now;
            var param = new DynamicParameters();
            param.Add("ORGDIST", trip.Originstationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("DESTST", trip.Destinationstationid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("DEPTIME", trip.Departuretime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("DURTIME", trip.Duratointime, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("AVASEATS", trip.Availableseats, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("PRICE", trip.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("CREATEDAT", trip.Createdat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("TRIPS_PACKAGE.CreateTrip", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteTrip(int id)
        {
            var param = new DynamicParameters();
            param.Add("Trip_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("TRIPS_PACKAGE.DeleteTrip", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Trip>> GetAllTrips()
        {
            var result = await _dbContext.Connection.QueryAsync<Trip>("TRIPS_PACKAGE.GetAllTrips", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<List<Trip>> GetTripsByOriginStation(int id)
        {
            var param = new DynamicParameters();
            param.Add("origin", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Trip>("TRIPS_PACKAGE.GetTripsByOriginStation", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<List<Trip>> GetTripsByOriginAndDest(int originId, int destId)
        {
            var p = new DynamicParameters();
            p.Add("origin", originId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Dest", destId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var res = _dbContext.Connection.Query<Trip>("TRIPS_PACKAGE.GetTripsByOriginAndDest", p, commandType: CommandType.StoredProcedure);

            return res.ToList();

        }

        public async Task<Trip> GetTripById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Trip_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Trip>("TRIPS_PACKAGE.GetTripByID", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateTrip(TripsDTO trip)
        {
            var param = new DynamicParameters();
            param.Add("trip_id", trip.Tripid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("ORGDIST", trip.Originstationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("DESTST", trip.Destinationstationid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("DEPTIME", trip.Departuretime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("DURTIME", trip.Duratointime, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("AVASEATS", trip.Availableseats, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("PRICE_new", trip.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("CREATEDAT", trip.Createdat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("TRIPS_PACKAGE.UpdateTrip", param, commandType: CommandType.StoredProcedure);
        }

        public List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("StartDate", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EndDate", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Search>("TRIPS_PACKAGE.SearchTripsBetweenDates", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task<List<Trip>> GetTripsByDestination(int id)
        {
            var param = new DynamicParameters();
            param.Add("destinationID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Trip>("TRIPS_PACKAGE.getTripsByDestination", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}