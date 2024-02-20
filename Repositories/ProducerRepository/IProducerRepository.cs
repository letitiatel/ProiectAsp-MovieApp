using Proiectasp.Models;
using Proiectasp.Repositories.GenericRepository;

namespace Proiectasp.Repositories.ProducerRepository
{
    public interface IProducerRepository : IGenericRepository<Producer>
    {
        public List<dynamic> GetAllWithJoin();
    }
}
