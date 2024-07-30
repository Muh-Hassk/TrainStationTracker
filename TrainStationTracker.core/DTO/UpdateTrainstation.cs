using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class UpdateTrainstation
    {
        public decimal Stationid { get; set; }
        public string? Stationname { get; set; } 
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Image { get; set; }

        public DateTime? Createdat { get; set; }
    }
}
