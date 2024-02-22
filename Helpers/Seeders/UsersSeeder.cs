using Proiectasp.Data;
using Proiectasp.Models;

namespace Proiectasp.Helpers.Seeders
{
    public class UsersSeeder
    {
        public readonly ProiectContext _proiectContext;

        public UsersSeeder(ProiectContext proiectContext)
        {
            _proiectContext = proiectContext;
        }

        public void SeedInitialUsers()
        {
            if (!_proiectContext.Users.Any())
            {
                var user1 = new User
                {
                    FirstName = "Fist name User 1",
                    LastName = "Last name User 1",
                   // IsDeleted = false,
                    Email = "user1@mail.com",
                    Userid = 0
                };

                var user2 = new User
                {
                    FirstName = "Fist name User 2",
                    LastName = "Last name User 2",
                   // IsDeleted = false,
                    Email = "user2@mail.com",
                    Userid = 0
                };

                _proiectContext.Users.Add(user1);
                _proiectContext.Users.Add(user2);

                _proiectContext.SaveChanges();
            }
        }
    }
}
