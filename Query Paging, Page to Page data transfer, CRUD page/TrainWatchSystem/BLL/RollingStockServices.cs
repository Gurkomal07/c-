#nullable disable
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public List<RollingStock> GetBy_RollingStock(string ReportingMark, int pageNumber,
                                                                   int pageSize, out int totalCount)
        {
            IEnumerable<RollingStock> info = _context.RollingStocks
                                                .Where(x => x.ReportingMark
                                                .Contains(ReportingMark));

            totalCount = info.Count();
            int skipRows = (pageNumber - 1) * pageSize;

            return info.Skip(skipRows).Take(pageSize).ToList();
        }

        public List<RollingStock> GetBy_RailCarType(int railcartype, int pageNumber,
                                                                   int pageSize, out int totalCount   )
        {
            IEnumerable<RollingStock> info = _context.RollingStocks
                                               .Where(x => x.RailCarTypeId == railcartype)
                                               .OrderBy(x => x.ReportingMark);

            totalCount = info.Count();
            int skipRows = (pageNumber - 1) * pageSize;

            return info.Skip(skipRows).Take(pageSize).ToList();
        }

        public RollingStock GetBy_ReportingMark(string searcharg)
        {
            RollingStock info = _context.RollingStocks
                                               .Where(x => x.ReportingMark.Equals(searcharg))
                                               .FirstOrDefault();

            return info;
        }

        public string RollingStock_AddRollingStock(RollingStock item)
        {
            if (item == null)
            {
                throw new ArgumentException("Reporting mark is missing");
            }

            RollingStock exist = _context.RollingStocks
                                .Where(x => x.ReportingMark.Equals(item.ReportingMark) &&
                                            x.Owner.Equals(item.Owner) && 
                                            x.RailCarTypeId == item.RailCarTypeId)
                                .FirstOrDefault();

            if (exist != null)
            {
                throw new Exception($"Rolling Stock you are trying to add is alredy in the record.");
            }

            _context.RollingStocks.Add(item);
            _context.SaveChanges();

            return item.ReportingMark;
        }



        public int RollingStock_UpdateRollingStock(RollingStock item)
        {
            bool exists = _context.RollingStocks.Any(x => x.ReportingMark.Equals(item.ReportingMark));

            if (!exists)
            {
                throw new Exception($"Rolling Stock you are trying to update is not in the record.");
            }

            EntityEntry<RollingStock> update = _context.Entry(item);
            update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges();
        }



        public int RollingStock_DeleteRollingStock(RollingStock item)
        {
            bool exists = _context.RollingStocks.Any(x => x.ReportingMark.Equals(item.ReportingMark));

            if (!exists)
            {
                throw new Exception($"Rolling Stock you are trying to update is not in the record.");
            }

            // physical delete
            EntityEntry<RollingStock> delete = _context.Entry(item);
            delete.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            // logical delete
            // EntityEntry<RollingStock> update = _context.Entry(item);
            // update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges();
        }
    }
}