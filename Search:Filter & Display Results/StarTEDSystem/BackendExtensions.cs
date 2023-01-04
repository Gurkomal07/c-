using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarTEDSystem.BLL;
using StarTEDSystem.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem
{
    public static class BackendExtensions
    {
        public static void StarTEDBackEndDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<StarTEDContext>(options);

            services.AddTransient<SchoolServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<StarTEDContext>();
                return new SchoolServices(context);
            });

            services.AddTransient<ProgramServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<StarTEDContext>();
                return new ProgramServices(context);
            });

            services.AddTransient<ProgramCoursesServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<StarTEDContext>();
                return new ProgramCoursesServices(context);
            });
        }
    }
}
