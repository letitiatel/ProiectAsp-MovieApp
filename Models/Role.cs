using Proiectasp.Models.Base;

namespace Proiectasp.Models
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }

        public int Idd { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
