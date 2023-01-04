#nullable disable
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public StarTEDSystem.Entities.Program GetBy_ProgramID(int? programId)
        {
            StarTEDSystem.Entities.Program info = _context.Programs
                                        .Where(x => x.ProgramID == programId)
                                        .FirstOrDefault();

            return info;
        }





        public int Program_AddProgram(StarTEDSystem.Entities.Program item)
        {
            if (item == null)
            {
                throw new ArgumentException("Program ID is missing");
            }

            StarTEDSystem.Entities.Program exist = _context.Programs
                                .Where(x => x.ProgramID == item.ProgramID &&
                                            x.ProgramName.Equals(item.ProgramName) &&
                                            x.SchoolCode == item.SchoolCode)
                                .FirstOrDefault();

            if (exist != null)
            {
                throw new Exception($"Program you are trying to add is alredy in the record.");
            }

            _context.Programs.Add(item);
            _context.SaveChanges();

            return item.ProgramID;
        }



        public int program_UpdateProgram(StarTEDSystem.Entities.Program item)
        {
            bool exists = _context.Programs.Any(x => x.ProgramID == item.ProgramID);

            if (!exists)
            {
                throw new Exception($"Program you are trying to update is not in the record.");
            }

            EntityEntry<StarTEDSystem.Entities.Program> update = _context.Entry(item);
            update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges();
        }



        public int Program_DeleteProgram(StarTEDSystem.Entities.Program item)
        {
            int courseNumber  = _context.ProgramCourses
                                        .Where(x => x.Program.ProgramID == item.ProgramID)
                                        .Count();



            if (courseNumber == null)
            {
                throw new Exception($"Program you are trying to delete is not in the record.");
            }
            

            EntityEntry<StarTEDSystem.Entities.Program> delete = _context.Entry(item);
            delete.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges();
        }
    }
}
