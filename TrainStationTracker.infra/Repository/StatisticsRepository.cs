using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;

namespace TrainStationTracker.infra.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {

        private readonly IDbContext _dbContext;
        
        public StatisticsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int GetNumberOfBookedTrips()
        {
            var result = _dbContext.Connection.Query<int>("STATISTICS_PACKAGE.GetNumberOfBookedTrips", commandType: CommandType.StoredProcedure);
            return Convert.ToInt32(result);
        }

        public int GetNumberOfTrainStations()
        {
            var result = _dbContext.Connection.Query<int>("STATISTICS_PACKAGE.GetNumberOfTrainStations", commandType: CommandType.StoredProcedure);
            return Convert.ToInt32(result);
        }

        public int GetNumberOfTrips()
        {
            var result = _dbContext.Connection.Query<int>("STATISTICS_PACKAGE.GetNumberOfTrips", commandType: CommandType.StoredProcedure);
            return Convert.ToInt32(result);
        }

        public int GetNumberOfUsers()
        {
            var result = _dbContext.Connection.Query<int>("STATISTICS_PACKAGE.GetNumberOfUsers", commandType: CommandType.StoredProcedure);
            return Convert.ToInt32(result);
        }
        public int GetTotalPrice()
        {
            var result = _dbContext.Connection.Query<int>("STATISTICS_PACKAGE.GetTotalPrice", commandType: CommandType.StoredProcedure);
            return result.Sum();
        }
    }
}
