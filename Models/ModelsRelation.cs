namespace Proiectasp.Models
{
    public class ModelsRelation
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
