using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IService
{
    public interface ILoginService
    {
       string Login(UserLogin user);
        Task Register(Register user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task UpdateProfile(UpdatProfile user);

        Task<bool> CheckUsername(string username);


    }
}
