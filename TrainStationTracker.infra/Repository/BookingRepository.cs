using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;
namespace TrainStationTracker.infra.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public BookingRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
        }

        public async Task BookTrip(BookTicket ticket)
        {
            // Find the trip using LINQ
            var trip = await _modelContext.Trips.FirstOrDefaultAsync(t => t.Tripid == ticket.Tripid);

            if (trip != null && trip.Availableseats > 0)
            {
                // Process the booking
                // Add the booking to the database
                var bookingEntity = new Booking
                {
                    Userid = ticket.Userid,
                    Tripid = ticket.Tripid,
                    Paymentstatus = ticket.Paymentstatus
                    // Map other properties as needed
                };

                _modelContext.Bookings.Add(bookingEntity);
                trip.Availableseats -= 1;

                // Save changes
                await _modelContext.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the trip is not found
                throw new Exception("Trip not found");
            }
        }

        public async Task<List<UserBookings>> GetUserBookings(int id)
        {
            var param = new DynamicParameters();
            param.Add("user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<UserBookings>("Bookings_Package.GetUserBookings", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
