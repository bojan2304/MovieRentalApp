using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieRentalDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> FindWhitDirector(Func<Movie, bool> predicate)
        {
            return _context.Movies.Include(a => a.Director).Where(predicate);
        }

        public IEnumerable<Movie> FindWhitDirectorAndCustomer(Func<Movie, bool> predicate)
        {
            return _context.Movies.Include(a => a.Director).Include(a => a.Customer).Where(predicate);
        }

        public IEnumerable<Movie> GetAllWhitDirector()
        {
            return _context.Movies.Include(a => a.Director);
        }
    }
}
