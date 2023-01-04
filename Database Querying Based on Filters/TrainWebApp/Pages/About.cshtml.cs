using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using TrainWatchSystem.BLL;
using TrainWatchSystem.Entities;
#endregion

namespace TrainWebApp.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly TrainWatchServices _trainwatchservices;


        public AboutModel(ILogger<AboutModel> logger, TrainWatchServices trainwatchservices)
        {
            _logger = logger;
           _trainwatchservices = trainwatchservices;
        }

        public DbVersion dbVersionInformation { get; set; }

        public void OnGet()
        {
            dbVersionInformation = _trainwatchservices.GetTrainWatchVersion();
        }
    }
}