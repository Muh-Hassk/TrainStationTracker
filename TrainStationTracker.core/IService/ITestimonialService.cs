using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IService
{
    public interface ITestimonialService
    {
        Task AcceptTestimonial(int id);
        Task RejectTestimonial(int id);

        Task WriteTestimonial(TestimonialDTO testimonial);

        public Task<List<Testimonial>> GetAllApprovedTestimonial();

        public Task<List<Testimonial>> GetAllTestimonial();

    }
}
