using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;
using TrainStationTracker.infra.Repository;

namespace TrainStationTracker.infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
           return await _loginRepository.GetAllUsers();   
        }

        public async Task<User> GetUserById(int id)
        {
            return await _loginRepository.GetUserById(id);
        }

        public async Task Register(Register user)
        {
            await _loginRepository.Register(user);
        }

        public async Task UpdateProfile(UpdatProfile user)
        {
            await _loginRepository.UpdateProfile(user);
        }

        public string Login(UserLogin user)
        {
            var result = _loginRepository.Login(user); 

            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Albaraa Salman Alshehry, Mohammad Hassan ALkuzaea , Amzan Abdullah Aldowagri"));
                var signCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("RoleId" , result.Roleid.ToString()),
                    new Claim("Userid", result.Userid.ToString())
                };

                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signCred);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
            }
        }
    }
}
