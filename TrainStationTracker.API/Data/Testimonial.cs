using System;
using System.Collections.Generic;

namespace TrainStationTracker.API.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public decimal Userid { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? Createdat { get; set; }
        public string Status { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
