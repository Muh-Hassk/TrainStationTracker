using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class UserBookings
    {
        public string Username { get; set; } = null!;
        public string destination_station { get; set; }
        public string origin_station { get; set; } 
        public DateTime Departuretime { get; set; }
        public decimal Duratointime { get; set; }
        public DateTime? Bookingtime { get; set; }
        public decimal Price { get; set; }
        public DateTime arrival_time {  get; set; }
        public string Paymentstatus { get; set; } = null!;
    }
}
