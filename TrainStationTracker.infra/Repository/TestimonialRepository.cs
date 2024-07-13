using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;

namespace TrainStationTracker.infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public TestimonialRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
        }
        public async Task AcceptTestimonial(int id)
        {
            var test = await _modelContext.Testimonials.FirstOrDefaultAsync(t => t.Testimonialid == id);
            if (test != null)
            {
                test.Status = "Approve";
                await _modelContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Testimonial not found");
            }
        }

        public async Task RejectTestimonial(int id)
        {
            var test = await _modelContext.Testimonials.FirstOrDefaultAsync(t => t.Testimonialid == id);
            if (test != null)
            {
                test.Status = "Reject";
                await _modelContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Testimonial not found");
            }
        }

        public async Task WriteTestimonial(TestimonialDB testimonial)
        {
        var UserTest = new Testimonial
            {
                Userid = testimonial.Userid,
                Content = testimonial.Content,
                Status = "Pending",
                Createdat = DateTime.Now
            };
            _modelContext.Testimonials.Add(UserTest);

            await _modelContext.SaveChangesAsync();
        }

        public async Task<List<Testimonial>> GetAllTestimonial()
        {
            {
                var result = await _dbContext.Connection.QueryAsync<Testimonial>(
                    "TESTIMONIALS_PACKAGE.GetAllTestimonials",
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public async Task<List<Testimonial>> GetAllApprovedTestimonial()
        {
            {
                var result = await _dbContext.Connection.QueryAsync<Testimonial>(
                    "TESTIMONIALS_PACKAGE.GetAllApprovedTestimonials",
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }
    }
}
