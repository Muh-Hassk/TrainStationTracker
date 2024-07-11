using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class UpdatProfile
    {
        public decimal Userid { get; set; }
        public string?Username { get; set; } 
        public string? Password { get; set; } 
        public string? Email { get; set; } 
        public DateTime? Createdat { get; set; }
        public string? Firstname { get; set; } 
        public string? Lastname { get; set; } 

    }
}
