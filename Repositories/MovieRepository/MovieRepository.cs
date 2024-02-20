using Proiectasp.Data;
using Proiectasp.Models;
using Proiectasp.Repositories.GenericRepository;
using System.Data.Entity;

namespace Proiectasp.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository

    {
        public MovieRepository(ProiectContext proiectContext) : base(proiectContext) { }

        public List<Movie> OrderByRating(int rating)
        {
            
            var moviesOrderedDesc1 = _table.OrderByDescending(x => x.Rating);
           
            var moviesOrderedDesc2 = from m in _table
                                       orderby m.Rating descending
                                       select m;

            return moviesOrderedDesc1.ToList();
        }


        public Movie Where(int rating)
        {
            var result1 = _table.Where(x => x.Rating < rating).FirstOrDefault();
            
            return result1;
        }

       
    }

}

