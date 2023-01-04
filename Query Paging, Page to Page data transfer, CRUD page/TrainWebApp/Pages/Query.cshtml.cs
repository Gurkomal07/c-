using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using TrainWatchSystem.BLL;      
using TrainWatchSystem.Entities;
using TrainWebApp.Helpers;
#endregion


namespace TrainWebApp.Pages
{
    public class QueryModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<QueryModel> _logger;
        private readonly RollingStockServices _rollingStockServices;
        private readonly RollingStockServices _railcartypeservices;
        private readonly TrainWatchServices _railcartypelist;


        public QueryModel(ILogger<QueryModel> logger,
            RollingStockServices rollingStockServices, RollingStockServices railcartypeServices, TrainWatchServices railcartypeservices)
        {
            _logger = logger;
            _rollingStockServices = rollingStockServices;
            _railcartypeservices = railcartypeServices;
            _railcartypelist = railcartypeservices;

        }
        #endregion

        [TempData]
        public string Feedback1 { get; set; }
        [TempData]
        public string Feedback2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        public List<RollingStock> RollingStockInfo { get; set; }

        public List<RailCarType> RailCarTypeList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [TempData]
        public string Feedback3 { get; set; }

        private const int PAGE_SIZE = 5;

        public Paginator Pager { get; set; }


        public void OnGet(int? currentPage)
        {
            int pageNumber = currentPage.HasValue ? currentPage.Value : 1;

            PageState current = new(pageNumber, PAGE_SIZE);

            int totalCount;

            if (!string.IsNullOrWhiteSpace(searcharg))
            {
              

                RollingStockInfo = _rollingStockServices.GetBy_RollingStock(searcharg, pageNumber,
                                                PAGE_SIZE, out totalCount);

                Pager = new Paginator(totalCount, current);
            }

            if (ID != 0)
            {
                RollingStockInfo = _railcartypeservices.GetBy_RailCarType(ID,pageNumber,
                                                PAGE_SIZE, out totalCount);

                Pager = new Paginator(totalCount, current);
            }

            


        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(searcharg))
            {
                Feedback1 = "Required: Search argument is empty.";
            }

            return RedirectToPage(new { searcharg = searcharg, ID = "" });
        }

        public IActionResult OnPostSelect()
        {
            if (ID == 0)
            {
                Feedback2 = "Required: No Car type selected.";
            }

            return RedirectToPage(new { ID = ID, searcharg = "" });
        }

        public IActionResult OnPostClear()
        {
            Feedback1 = "";
            Feedback2 = "";
            Feedback3 = "";
            return RedirectToPage(new { searcharg = (string?)null, ID = (int?)null });
        }

        public IActionResult OnPostNew()
        {
            return RedirectToPage("/CRUDPage");
        }
    }
}