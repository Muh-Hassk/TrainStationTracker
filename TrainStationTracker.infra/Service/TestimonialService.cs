using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.infra.Service
{
    public class TestimonialService : ITestimonialService
    {

        private readonly  ITestimonialRepository _testimonialRepository;

        

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public Task AcceptTestimonial(int id)
        {
            return _testimonialRepository.AcceptTestimonial(id);
        }

        public Task<List<Testimonial>> GetAllApprovedTestimonial()
        {
            return _testimonialRepository.GetAllApprovedTestimonial();
        }

        public Task<List<Testimonial>> GetAllTestimonial()
        {
            return _testimonialRepository.GetAllTestimonial();
        }

        public Task RejectTestimonial(int id)
        {
            return _testimonialRepository.RejectTestimonial(id);
        }

        public Task WriteTestimonial(TestimonialDTO testimonial)
        {
            return _testimonialRepository.WriteTestimonial(testimonial);
        }
    }
}
