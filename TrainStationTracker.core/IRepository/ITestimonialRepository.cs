using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IRepository
{
    public interface ITestimonialRepository
    {
        Task AcceptTestimonial(int id);
        Task RejectTestimonial(int id);

        Task WriteTestimonial(TestimonialDB testimonial);

        public Task<List<Testimonial>> GetAllTestimonial();

        public Task<List<Testimonial>> GetAllApprovedTestimonial();




    }
}
