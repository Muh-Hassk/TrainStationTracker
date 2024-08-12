using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IService
{
    public interface IBookingService
    {
        Task BookTrip(BookTicket Ticket);
        Task<List<UserBookings>> GetUserBookings(int id);

    }
}
