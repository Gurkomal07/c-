using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A03WebApp.Pages
{
    public class CRUDModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? programid { get; set; }
        public void OnGet()
        {
        }
    }
}
