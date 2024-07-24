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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task CreateContactUsPage(Contactuspage contactuspage)
        {
            await _contactRepository.CreateContactUsPage(contactuspage);
        }

        public async Task DeleteContactUsPage(int id_)
        {
            await _contactRepository.DeleteContactUsPage(id_);
        }

        public async Task<List<Contactuspage>> GetAllContactUsPage()
        {
            return await _contactRepository.GetAllContactUsPage();
        }

        public async Task UpdateContactUsPage(Contactuspage contactuspage)
        {
            await _contactRepository.UpdateContactUsPage(contactuspage);
        }
    }
}
