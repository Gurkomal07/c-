using A03WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using StarTEDSystem.BLL;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

namespace A03WebApp.Pages
{
    public class QueryModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SchoolServices _schoolServices;
        private readonly ProgramServices _programServices;


        public QueryModel(ILogger<IndexModel> logger, SchoolServices schoolServices,
                        ProgramServices programServices)
        { 
            _logger = logger;
            _schoolServices = schoolServices;
            _programServices = programServices;
        }

        [BindProperty(SupportsGet = true)]
        public string partialProgramName { get; set; }

        public List<StarTEDSystem.Entities.Program> ProgramsList { get; set; }

        public List<School> SchoolsList { get; set; }


        private const int PAGE_SIZE = 5;

        public Paginator Pager { get; set; }

        public void OnGet(int? currentPage )
        {
            int pageNumber = currentPage.HasValue ? currentPage.Value : 1;

            PageState current = new(pageNumber, PAGE_SIZE);

            int totalCount;



            ProgramsList = _programServices.Programs_List(partialProgramName, pageNumber, 
                                                PAGE_SIZE, out totalCount);

            Pager = new Paginator(totalCount, current);

            SchoolsList = _schoolServices.Schools_List();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage(new { partialProgramName = partialProgramName });
        }
    }
}
