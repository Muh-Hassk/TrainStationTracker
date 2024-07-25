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
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly IDbContext _dbContext;

        public AboutUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            var param = new DynamicParameters();
            param.Add("title", aboutuspage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("content", aboutuspage.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("image", aboutuspage.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("AboutUsPagePackage.CreateAboutUsPage", param, commandType: CommandType.StoredProcedure);
        }


        public async Task DeleteAboutUsPage(int id_)
        {
            var param = new DynamicParameters();
            param.Add("id_", id_, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("AboutUsPagePackage.DeleteAboutUsPage", param, commandType: CommandType.StoredProcedure);
        }



        public async Task<List<Aboutuspage>> GetAllAboutUsPage()
        {
            var result = await _dbContext.Connection.QueryAsync<Aboutuspage>("AboutUsPagePackage.GetAllAboutUsPage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            var param = new DynamicParameters();
            param.Add("id_update", aboutuspage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("title_update", aboutuspage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("content_update", aboutuspage.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("image_update", aboutuspage.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("AboutUsPagePackage.UpdateAboutUsPage", param, commandType: CommandType.StoredProcedure);
        }
    }
}
