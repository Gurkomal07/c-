
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using TrainWatchSystem.Entities;
#endregion

namespace TrainWatchSystem.DAL
{
   
    internal class TrainWatchContext : DbContext
    {
        public TrainWatchContext()
        {

        }

        public TrainWatchContext(DbContextOptions<TrainWatchContext> options) : base(options)
        {

        }

        public DbSet<DbVersion> DbVersions { get; set; }
        public DbSet<RollingStock> RollingStocks { get; set; }

        public DbSet<RailCarType> RailCarTypes { get; set; }


    }
}
