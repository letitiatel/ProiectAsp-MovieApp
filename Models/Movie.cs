using Proiectasp.Models.Base;

namespace Proiectasp.Models
{
    public class Movie: BaseEntity
    {
        public string? Name { get; set; }
        public string? Release_date { get; set; }
        public string? Type_of_movie { get; set; }
        public int Rating { get; set; }

        public Producer Producer { get; set; }
      

        public ICollection<ModelsRelation> ModelsRelations { get; set; }
    }
}
