using Dapper;
using Microsoft.EntityFrameworkCore;
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
    public class TrainStationRepository : ITrainStationRepository
    {
        private readonly IDbContext _dbContext;
        

        public TrainStationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task CreateTrainstation(Trainstation trainstation)
        {
           
            trainstation.Createdat = DateTime.Now;
            var param = new DynamicParameters();
            param.Add("Station_name", trainstation.Stationname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Lat", trainstation.Latitude, DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("Longi", trainstation.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("Created_date", trainstation.Createdat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("Image_new", trainstation.Image, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = await _dbContext.Connection.ExecuteAsync("TRAINSTATION_PACKAGE.CreateStation", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteTrainstation(int id)
        {
            var param = new DynamicParameters();
            param.Add("Station_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("TRAINSTATION_PACKAGE.DeleteStation", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Trainstation>> GetAllTrainStations()
        {
            {
                var result = await _dbContext.Connection.QueryAsync<Trainstation>(
                    "TrainStation_Package.GetAllStations",
                    commandType: CommandType.StoredProcedure
                );
                
                return result.ToList();
            }
        }

        public async Task<Trainstation> GetTrainstationById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Station_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Trainstation>("TrainStation_Package.GetStationById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Trainstation>> GetTrainStationByName(Name name)
        {
            var p = new DynamicParameters();
            p.Add("Station_Name", name.name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Trainstation>(
                "TrainStation_Package.GetStationsByName",
                p,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }


        public async Task UpdateTrainstation(UpdateTrainstation trainstation)
        {
           
            var param = new DynamicParameters();
            param.Add("Station_id", trainstation.Stationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("Station_name", trainstation.Stationname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Lat", trainstation.Latitude, DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("Longi", trainstation.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("Image_new", trainstation.Image, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = await _dbContext.Connection.ExecuteAsync("TRAINSTATION_PACKAGE.UpdateStation", param, commandType: CommandType.StoredProcedure);
        }
    }
}

