using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.BLL
{
    public class ProgramServices
    {
        private readonly StarTEDContext _context;

        public ProgramServices(StarTEDContext regcontext)
        {
            _context = regcontext;
        }

        public List<StarTEDSystem.Entities.Program> Programs_List(string partialname, int pageNumber,
                                                                   int pageSize, out int totalCount)
        {
            IEnumerable<StarTEDSystem.Entities.Program> info = _context.Programs
                                        .Where(x => x.ProgramName.Contains(partialname))
                                        .OrderBy(x => x.ProgramName);

            totalCount = info.Count();

            int skipRows = (pageNumber - 1) * pageSize;



            return info.Skip(skipRows).Take(pageSize).ToList();
        }
    }
}
