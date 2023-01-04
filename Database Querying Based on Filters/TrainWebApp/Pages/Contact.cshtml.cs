using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainWebApp.Pages
{
	public class ContactModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Topic { get; set; }

        [BindProperty]
        public string MessageTitle { get; set; }

        [BindProperty]
        public string MessageBody { get; set; }

        public string Feedback { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Feedback = $"Email: {Email}, Topic: {Topic}, Message Title: {MessageTitle}";
        }
    }
}
