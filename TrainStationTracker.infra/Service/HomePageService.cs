using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.infra.Service
{
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepository _homeRepository;

        public HomePageService(IHomePageRepository homePage)
        {
            _homeRepository = homePage;
        }

        public async Task CreateHomePage(Homepage homePage)
        {
            await _homeRepository.CreateHomePage(homePage);
        }

        public async Task DeleteHomePage(int id_)
        {
            await _homeRepository.DeleteHomePage(id_);
        }

        public async Task<List<Homepage>> GetAllHomePage()
        {
            return await _homeRepository.GetAllHomePage();
        }

        public async Task UpdateHomePage(Homepage homepage)
        {
            await _homeRepository.UpdateHomePage(homepage);
        }
    }
}
