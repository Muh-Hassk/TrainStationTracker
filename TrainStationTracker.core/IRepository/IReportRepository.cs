﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IRepository
{
    public interface IReportRepository
    {
        List<Search> MonthlyReport(string month, int year);
        List<Search> AnnualReport(int year);

    }
}
