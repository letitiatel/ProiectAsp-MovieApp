namespace Proiectasp.Models.DTOs
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? Release_date { get; set; }
        public string? Type_of_movie { get; set; }
        public int Rating { get; set; }
    }
}
