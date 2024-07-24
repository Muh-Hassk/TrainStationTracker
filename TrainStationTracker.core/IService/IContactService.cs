using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;

namespace TrainStationTracker.core.IService
{
    public interface IContactService
    {
        Task CreateContactUsPage(Contactuspage contactuspage);

        Task<List<Contactuspage>> GetAllContactUsPage();

        Task UpdateContactUsPage(Contactuspage contactuspage);

        Task DeleteContactUsPage(int id_);

    }
}
