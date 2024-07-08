using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
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
    }
}

