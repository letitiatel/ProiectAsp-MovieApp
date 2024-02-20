using Proiectasp.Models.Base;

namespace Proiectasp.Models
{
    public class User : BaseEntity
    {
        public int Userid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public Role Role { get; set; }

        public Guid RoleId { get; set; }

        public ICollection<ModelsRelation> ModelsRelations { get; set; }

    }
}
