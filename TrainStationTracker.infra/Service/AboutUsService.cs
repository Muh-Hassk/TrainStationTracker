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
    public class AboutUsService : IAboutUsService
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }

        public async Task CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            await _aboutUsRepository.CreateAboutUsPage(aboutuspage);
        }

        public async Task DeleteAboutUsPage(int id_)
        {
            await _aboutUsRepository.DeleteAboutUsPage(id_);
        }

        public async Task<List<Aboutuspage>> GetAllAboutUsPage()
        {
            return await _aboutUsRepository.GetAllAboutUsPage();
        }

        public async Task UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            await _aboutUsRepository.UpdateAboutUsPage(aboutuspage);
        }
    }
}
