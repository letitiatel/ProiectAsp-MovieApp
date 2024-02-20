using Proiectasp.Models;
using Proiectasp.Repositories.GenericRepository;

namespace Proiectasp.Repositories.MovieRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        List<Movie> OrderByRating(int rating);

        public Movie Where(int rating);


    }
}
