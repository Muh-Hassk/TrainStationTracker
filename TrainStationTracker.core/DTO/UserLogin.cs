using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class UserLogin
    {
        public string? Username { get; set; } 
        public string? Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Userid { get; set; }
    }
}
