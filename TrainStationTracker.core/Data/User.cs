using System;
using System.Collections.Generic;

namespace TrainStationTracker.core.Data
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Roleid { get; set; }
        public DateTime? Createdat { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
