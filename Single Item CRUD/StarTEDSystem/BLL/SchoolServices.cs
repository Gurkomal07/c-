using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.BLL
{
    public class SchoolServices
    {
        private readonly StarTEDContext _context;

        public SchoolServices(StarTEDContext regcontext)
        {
            _context = regcontext;
        }

        public List<School> Schools_List()
        {
            IEnumerable<School> info = _context.Schools
                                        .OrderBy(x => x.SchoolName);

            return info.ToList();
        } 
    }
}
