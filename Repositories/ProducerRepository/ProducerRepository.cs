using Proiectasp.Data;
using Proiectasp.Models;
using Proiectasp.Repositories.GenericRepository;
using Proiectasp.Repositories.RoleRepository;
using System.Data.Entity;

namespace Proiectasp.Repositories.ProducerRepository
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(ProiectContext proiectContext) : base(proiectContext) { }

        public List<dynamic> GetAllWithJoin()
        {
            var result = _proiectContext.Producers.Join(_proiectContext.Movies, producer => producer.Id, movie => movie.Id,
                (producer, movie) => new { producer, movie }).Select(ob => ob.producer);


            return null;
        }

        

    }
}
