using Proiectasp.Models;
using Proiectasp.Models.DTOs;
using Proiectasp.Repositories.GenericRepository;

namespace Proiectasp.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername(string lastname);

        Task<List<User>> FindAll();

        Task<List<User>> FindAllActive();
    }
}
