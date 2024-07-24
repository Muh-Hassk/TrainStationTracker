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
    public class HomePageRepository : IHomePageRepository
    {
        private readonly IDbContext _dbContext;

        public HomePageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateHomePage(Homepage homePage)
        {
            var param = new DynamicParameters();
            param.Add("title", homePage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("content", homePage.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("image", homePage.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("HomePagePackage.CreateHomePage", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteHomePage(int id_)
        {
            var param = new DynamicParameters();
            param.Add("id_", id_, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("HomePagePackage.DeleteHomePage", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Homepage>> GetAllHomePage()
        {
            var result = await _dbContext.Connection.QueryAsync<Homepage>("HomePagePackage.GetAllHomePage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task UpdateHomePage(Homepage homepage)
        {
            var param = new DynamicParameters();
            param.Add("id_update", homepage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("title_update", homepage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("content_update", homepage.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("image_update", homepage.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("HomePagePackage.UpdateHomePage", param, commandType: CommandType.StoredProcedure);
        }
    }
}
