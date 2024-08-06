using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpPost]
        public async Task CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            await _aboutUsService.CreateAboutUsPage(aboutuspage);
        }

        [HttpDelete]
        public async Task DeleteAboutUsPage(int id_)
        {
            await _aboutUsService.DeleteAboutUsPage(id_);
        }

        [HttpGet]
        public async Task<List<Aboutuspage>> GetAllAboutUsPage()
        {
            return await _aboutUsService.GetAllAboutUsPage();
        }

        [HttpPut]
        public async Task UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            aboutuspage.Id = 1;
            await _aboutUsService.UpdateAboutUsPage(aboutuspage);
        }
    }
}
