using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TrainWatchSystem.DAL;
using TrainWatchSystem.BLL;
#endregion

namespace TrainWatchSystem
{
    public static class StartupExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
      
            services.AddDbContext<TrainWatchContext>(options);

           
            services.AddTransient<TrainWatchServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<TrainWatchContext>();

                return new TrainWatchServices(context);
            });

            services.AddTransient<RollingStockServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<TrainWatchContext>();

                return new RollingStockServices(context);
            });

        }


    }
}
