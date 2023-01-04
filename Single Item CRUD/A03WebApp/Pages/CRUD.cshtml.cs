#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using StarTEDSystem.Entities;
using StarTEDSystem.BLL;

namespace A03WebApp.Pages
{
    public class CRUDModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProgramServices _programServices;
        private readonly SchoolServices _schoolServices;
        private readonly ProgramCoursesServices _programCoursesServices;

        public CRUDModel(ILogger<IndexModel> logger, ProgramServices programServices,
                             SchoolServices schoolServices, ProgramCoursesServices programCoursesServices)
        {
            _logger = logger;
            _programServices = programServices;
            _schoolServices = schoolServices;
            _programCoursesServices = programCoursesServices;
           
        }

        [BindProperty(SupportsGet = true)]
        public int? programid { get; set; }

        [BindProperty]
        public StarTEDSystem.Entities.Program ProgramByID { get; set; }

        [TempData]
        public string Feedback { get; set; }

        public List<School> SchoolsList { get; set; }

        public int TotalProgramsByID { get; set; }

        public void OnGet()
        {
            if (programid != null)
            {
               ProgramByID  = _programServices.GetBy_ProgramID(programid);
            }

            SchoolsList = _schoolServices.Schools_List();            
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Query");
        }

        public IActionResult OnPostNew()
        {
            try
            {
                int newProgramID = _programServices.Program_AddProgram(ProgramByID);
                Feedback = $"Program ID: ({newProgramID}) is added to the data";

                return RedirectToPage(new { reportingMark = newProgramID });
            }
            catch (ArgumentNullException ex)
            {
                Feedback = GetInnerException(ex).Message;
                return Page();
            }
        }

        public IActionResult OnPostUpdate()
        {
            try
            {
                int NumberOfRowsAffected = _programServices.program_UpdateProgram(ProgramByID);

                if (NumberOfRowsAffected > 0)
                {
                    Feedback = $"Program ID: ({NumberOfRowsAffected}) is updated in the data";
                }
                else
                {
                    Feedback = $"No data affected.";
                }

                return RedirectToPage(new { programid = programid });
            }
            catch (ArgumentNullException ex)
            {
                Feedback = GetInnerException(ex).Message;
                return Page();
            }
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                int NumberOfRowsAffected = _programServices.Program_DeleteProgram(ProgramByID);

                if (NumberOfRowsAffected > 0)
                {
                    Feedback = $"Program ID: ({NumberOfRowsAffected}) has been deleted from the data";
                }
                else
                {
                    Feedback = $"No data affected.";
                }

                return RedirectToPage(new { programid = programid });
            }
            catch (ArgumentNullException ex)
            {
                Feedback = GetInnerException(ex).Message;

                return Page();
            }
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            ModelState.Clear();
            return RedirectToPage(new { programid = (int?)null });
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
