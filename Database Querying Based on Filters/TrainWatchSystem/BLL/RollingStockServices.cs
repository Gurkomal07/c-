using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using TrainWatchSystem.DAL;
using TrainWatchSystem.Entities;
#endregion


namespace TrainWatchSystem.BLL
{
    public class RollingStockServices
    {

        private readonly TrainWatchContext _context;

        internal RollingStockServices(TrainWatchContext regcontext)
        {
            _context = regcontext;
        }

        public List<RollingStock> GetBy_RollingStock(string ReportingMark)
        {
            IEnumerable<RollingStock> info = _context.RollingStocks
                                                .Where(x => x.ReportingMark
                                                .Contains(ReportingMark));

            return info.ToList();
        }

        public List<RollingStock> GetBy_RailCarType(int railcartype)
        {



            IEnumerable<RollingStock> info = _context.RollingStocks
                                               .Where(x => x.RailCarTypeId == railcartype)
                                               .OrderBy(x => x.ReportingMark);


            return info.ToList();
        }

    }
}