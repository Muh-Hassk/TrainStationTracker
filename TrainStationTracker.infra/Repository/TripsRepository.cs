using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;

namespace TrainStationTracker.infra.Repository
{
    public class TripsRepository : ITripsRepository
    {
        private readonly IDbContext _dbContext;
        public TripsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Search> SearchTripsBetweenDates(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("StartDate", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EndDate", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Search>("TRIPS_PACKAGE.SearchTripsBetweenDates", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
