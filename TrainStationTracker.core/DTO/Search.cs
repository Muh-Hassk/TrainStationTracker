using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class Search
    {
        public string? USERNAME { get; set; }
        public DateTime? BOOKINGTIME { get; set; }
        public int? ORIGINSTATIONID { get; set; }
        public int? DESTINATIONSTATIONID { get; set; }
        public int? PRICE { get; set; }
    }
}
