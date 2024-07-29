using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public async Task CreateContactUsPage(Contactuspage contactuspage)
        {
            await _contactService.CreateContactUsPage(contactuspage);
        }

        [HttpGet]
        public async Task<List<Contactuspage>> GetAllContactUsPage()
        {
            return await _contactService.GetAllContactUsPage();
        }

        [HttpPut]
        public async Task UpdateContactUsPage(Contactuspage contactuspage)
        {
            contactuspage.Id = 1;
            await _contactService.UpdateContactUsPage(contactuspage);
        }

        [HttpDelete]

        public async Task DeleteContactUsPage(int id_)
        {
            await _contactService.DeleteContactUsPage(id_);
        }
    }
}
