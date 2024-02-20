using Proiectasp.Models.Base;

namespace Proiectasp.Models
{
    public class Producer : BaseEntity
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Awards { get; set; }

        public ICollection<Movie>? Movies { get; set; }

        public ProducerDetails ProducerDetails { get; set; }
    }
}
