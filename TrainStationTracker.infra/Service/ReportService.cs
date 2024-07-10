using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.infra.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService (IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public List<Search> MonthlyReport(string month, int year)
        {
            return _reportRepository.MonthlyReport(month, year);
        }

        public List<Search> AnnualReport(int year)
        {
            return _reportRepository.AnnualReport(year);
        }
    }
}
