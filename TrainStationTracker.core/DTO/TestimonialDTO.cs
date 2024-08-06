using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class TestimonialDTO
    {
        public decimal Testimonialid { get; set; }
        public decimal Userid { get; set; }
        public string Content { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? Createdat { get; set; }
    }
}
