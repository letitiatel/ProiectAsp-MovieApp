using Proiectasp.Data;
using Proiectasp.Models;
using Proiectasp.Repositories.GenericRepository;
using Proiectasp.Repositories.MovieRepository;
using System.Data.Entity;

namespace Proiectasp.Repositories.RoleRepository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ProiectContext proiectContext) : base(proiectContext) { }

        public void GroupBy()
        {
            //var groupedRoles = _table.GroupBy(x => x.Id);

            var groupedRoles2 = from r in _table
                                   group r by r.Name;

            foreach (var roleGroupedByName in groupedRoles2)
            {
                Console.WriteLine("Roles group name: " + roleGroupedByName.Key);

               
            }
        }

        public List<Role> GetAllWithInclude()
        {

            return _table.Include(r => r.Users).ToList();

           
        }
    }
}
