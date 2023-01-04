using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.BLL
{
    public class ProgramCoursesServices
    {
        private readonly StarTEDContext _context;

        public ProgramCoursesServices(StarTEDContext regcontext)
        {
            _context = regcontext;
        }
    }
}
