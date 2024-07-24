using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;

namespace TrainStationTracker.core.IRepository
{
    public interface IHomePageRepository
    {
        Task CreateHomePage(Homepage homePage);
        Task<List<Homepage>> GetAllHomePage();

        Task UpdateHomePage(Homepage homepage);

        Task DeleteHomePage(int id_);
    }
}
