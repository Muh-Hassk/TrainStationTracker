using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;

namespace TrainStationTracker.infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _dbContext.Connection.QueryAsync<User>("USERS_PACKAGE.GetAllUsers", commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            var param = new DynamicParameters();
            param.Add("User_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<User>("USERS_PACKAGE.GetUserById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task Register(Register user)
        {
            user.Createdat= DateTime.Now;
            var param = new DynamicParameters();
            param.Add("User_name", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Pass", user.Password, DbType.String, direction: ParameterDirection.Input);
            param.Add("first_name", user.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("last_name", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Role_id", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("Created_at",user.Createdat,dbType:DbType.DateTime, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("USERS_PACKAGE.CreateUser", param, commandType: CommandType.StoredProcedure);

        }

        public async Task UpdateProfile(UpdatProfile user)
        {
           
            var param = new DynamicParameters();
            param.Add("User_id", user.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_User_name", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("new_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("new_email", user.Email, DbType.String, direction: ParameterDirection.Input);
            
            param.Add("FIRST_NAME", user.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("LAST_NAME", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = await _dbContext.Connection.ExecuteAsync("USERS_PACKAGE.UpdateUser", param, commandType: CommandType.StoredProcedure);
        }

        public UserLogin Login(UserLogin user)
        {
            var p = new DynamicParameters();
            p.Add("user_name", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Pass", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<UserLogin>("USERS_PACKAGE.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<bool> CheckUsername(string username)
        {
            var p = new DynamicParameters();
            p.Add("user_name", username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("c_id", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("USERS_PACKAGE.CheckuserName", p, commandType: CommandType.StoredProcedure);

            bool isUsernameTaken = p.Get<bool>("c_id");
            return isUsernameTaken;
        }

    }
}
