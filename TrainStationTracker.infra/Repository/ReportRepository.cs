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
    public class ReportRepository : IReportRepository
    {
        private readonly IDbContext _dbContext;

        public ReportRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Search> MonthlyReport(string month, int year)
        {
            var p = new DynamicParameters();
            p.Add("month", month, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("year", year, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Search>("Bookings_Package.MonthlyReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Search> AnnualReport(int year)
        {
            var p = new DynamicParameters();
            p.Add("year", year, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Search>("Bookings_Package.AnnualReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
