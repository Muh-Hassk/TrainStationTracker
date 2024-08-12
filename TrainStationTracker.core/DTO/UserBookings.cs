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
        public decimal Originstationid { get; set; }
        public decimal Destinationstationid { get; set; } 
        public string Stationname { get; set; } = null!;
        public DateTime Departuretime { get; set; }
        public decimal Duratointime { get; set; }
        public DateTime? Bookingtime { get; set; }
        public decimal Price { get; set; }
        public string Paymentstatus { get; set; } = null!;
    }
}
