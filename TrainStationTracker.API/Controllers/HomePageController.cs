using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;
        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        [HttpPost]
        public async Task CreateHomePage(Homepage homePage)
        {
            await _homePageService.CreateHomePage(homePage);
        }

        [HttpDelete]
        public async Task DeleteHomePage(int id_)
        {
            await _homePageService.DeleteHomePage(id_);
        }

        [HttpGet]
        public async Task<List<Homepage>> GetAllHomePage()
        {
            return await _homePageService.GetAllHomePage();
        }

        [HttpPut]
        public async Task UpdateHomePage(Homepage homepage)
        {
            await _homePageService.UpdateHomePage(homepage);
        }
    }
}
