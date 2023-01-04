using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TrainWatchSystem.BLL;
using TrainWatchSystem.Entities;

namespace TrainWebApp.Pages
{
    public class CRUDPageModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RollingStockServices _rollingStockServices;
        private readonly RollingStockServices _railcartypeservices;
        private readonly TrainWatchServices _trainWatchServices;

        public CRUDPageModel(ILogger<IndexModel> logger,
            RollingStockServices rollingStockServices, RollingStockServices railcartypeServices,
            TrainWatchServices trainWatchServices)
        {
            _logger = logger;
            _rollingStockServices = rollingStockServices;
            _railcartypeservices = railcartypeServices;
            _trainWatchServices = trainWatchServices;

        }


        [BindProperty(SupportsGet = true)]
        public string? reportingMark { get; set; }


        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        [BindProperty]
        public RollingStock RollingStocke { get; set; }

        [TempData]
        public string Feedback { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(reportingMark))
            {
                RollingStocke = _rollingStockServices.GetBy_ReportingMark(reportingMark);
            }
        }


        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Query");
        }

        public IActionResult OnPostNew()
        {
            try
            {
                string newReportingMark = _rollingStockServices.RollingStock_AddRollingStock(RollingStocke);
                Feedback = $"Repoting Mark: ({newReportingMark}) is added to the data";

                return RedirectToPage(new { reportingMark = newReportingMark });
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(GetInnerException(ex).Message);

                return Page();
            }
        }

        public IActionResult OnPostUpdate()
        {
            try
            {
                int NumberOfRowsAffected = _rollingStockServices.RollingStock_UpdateRollingStock(RollingStocke);

                if (NumberOfRowsAffected > 0)
                {
                    Feedback = $"Repoting Mark: ({NumberOfRowsAffected}) is updated in the data";
                }
                else
                {
                    Feedback = $"No data affected.";
                }

                return RedirectToPage(new { reportingMark = reportingMark });
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(GetInnerException(ex).Message);

                return Page();
            }
        }


        public IActionResult OnPostDelete()
        {
            try
            {
                int NumberOfRowsAffected = _rollingStockServices.RollingStock_DeleteRollingStock(RollingStocke);

                if (NumberOfRowsAffected > 0)
                {
                    Feedback = $"Repoting Mark: ({NumberOfRowsAffected}) has been deleted from the data";
                }
                else
                {
                    Feedback = $"No data affected.";
                }

                return RedirectToPage(new { reportingMark = reportingMark });
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(GetInnerException(ex).Message);

                return Page();
            }
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            ModelState.Clear();
            return RedirectToPage(new { reportingMark = (string?)null });
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
