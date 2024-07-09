using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class Register
    {
        
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 
        public decimal Roleid { get; set; }
        public string Firstname { get; set; } 
        public string Lastname { get; set; }
        public DateTime? Createdat { get; set; } = DateTime.Now;
    }
}
