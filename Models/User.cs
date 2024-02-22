using Proiectasp.Data.Enums;
using Proiectasp.Models.Base;
using System.Text.Json.Serialization;


namespace Proiectasp.Models
{
    public class User : BaseEntity
    {
        public int Userid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public Role Role { get; set; }
        public Role1 Role1 { get; set; }

        public Guid RoleId { get; set; }

        public ICollection<ModelsRelation> ModelsRelations { get; set; }

    }
}
