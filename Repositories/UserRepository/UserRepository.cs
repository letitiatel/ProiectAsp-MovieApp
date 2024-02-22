
using Proiectasp.Data;
using Proiectasp.Models;
using Proiectasp.Models.DTOs;
using Proiectasp.Repositories.GenericRepository;
using System.Data.Entity;

namespace Proiectasp.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectContext proiectContext) : base(proiectContext)
        {
        }

       
        public async Task<List<User>> FindAll()
        {
            return await _table.ToListAsync();
        }

        public Task<List<User>> FindAllActive()
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByUsername(string email)
        {
            return (await _table.FirstOrDefaultAsync(u => u.Email.Equals(email)))!;
        }

        User IUserRepository.FindByUsername(string lastname)
        {
            throw new NotImplementedException();
        }
    }
}
