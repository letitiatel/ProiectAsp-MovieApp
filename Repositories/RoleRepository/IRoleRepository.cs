using Proiectasp.Models;
using Proiectasp.Repositories.GenericRepository;

namespace Proiectasp.Repositories.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public List<Role> GetAllWithInclude();
        public void GroupBy();
    }
}
