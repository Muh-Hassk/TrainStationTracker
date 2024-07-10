using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainStationTracker.core.DTO;
using TrainStationTracker.core.IService;

namespace TrainStationTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("{month}/{year}")]

        public List<Search> MonthlyReport(string month, int year)
        {
            return _reportService.MonthlyReport(month, year);
        }

        [HttpGet]
        [Route("{year}")]

        public List<Search> AnnualReport(int year)
        {
            return _reportService.AnnualReport(year);
        }
    }
}
