﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class PaymentRequest
    {
        public string Token { get; set; }
        public long Amount { get; set; }
    }
}
