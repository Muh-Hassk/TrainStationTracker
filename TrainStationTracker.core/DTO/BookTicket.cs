using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class BookTicket
    {
        public decimal Bookingid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public DateTime? Bookingtime { get; set; }
        public string Paymentstatus { get; set; } = null!;

    }
}
