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
    public class ContactRepository : IContactRepository
    {
        private readonly IDbContext _dbContext;

        public ContactRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateContactUsPage(Contactuspage contactuspage)
        {
            var param = new DynamicParameters();
            param.Add("address_new", contactuspage.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("phone_new", contactuspage.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("email_new", contactuspage.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("ContactUsPagePackage.CreateContactUsPage", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Contactuspage>> GetAllContactUsPage()
        {
            var result = await _dbContext.Connection.QueryAsync<Contactuspage>("ContactUsPagePackage.GetAllContactUsPage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task UpdateContactUsPage(Contactuspage contactuspage)
        {
            var param = new DynamicParameters();
            param.Add("id_", contactuspage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("address_Update", contactuspage.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("phone_Update", contactuspage.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("email_Update", contactuspage.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("ContactUsPagePackage.UpdateContactUsPage", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteContactUsPage(int id_)
        {
            var param = new DynamicParameters();
            param.Add("id_", id_, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("ContactUsPagePackage.DeleteContactUsPage", param, commandType: CommandType.StoredProcedure);
        }
    }
}
