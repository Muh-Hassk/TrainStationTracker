using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;

namespace TrainStationTracker.core.IService
{
    public interface IAboutUsService
    {
        Task CreateAboutUsPage(Aboutuspage aboutuspage);

        Task<List<Aboutuspage>> GetAllAboutUsPage();

        Task UpdateAboutUsPage(Aboutuspage aboutuspage);

        Task DeleteAboutUsPage(int id_);
    }
}
