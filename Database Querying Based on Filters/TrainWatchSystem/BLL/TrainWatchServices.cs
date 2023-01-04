#nullable disable
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
    public class TrainWatchServices
    {
        
        private readonly TrainWatchContext _context;

        internal TrainWatchServices(TrainWatchContext regcontext)
        {
            _context = regcontext;
        }

        public DbVersion GetTrainWatchVersion()
        {

            DbVersion info = _context.DbVersions.FirstOrDefault();
            return info;
        }

        /*public List<RailCarType> GetRailCar_Type()
        {
            IEnumerable<RailCarType> info = _context.RailCarTypes.OrderBy(y => y.Name);

            return info.ToList();
        }
*/
    }
}
