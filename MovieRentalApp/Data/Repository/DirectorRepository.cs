using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data.Repository
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieRentalDbContext context) : base(context)
        {
        }

        public IEnumerable<Director> GetAllWhitMovies()
        {
            return _context.Directors.Include(d => d.Movies);
        }

        public Director GetWhitMovies(int id)
        {
            return _context.Directors.Where(d => d.Id == id).Include(d => d.Movies).FirstOrDefault();
        }
    }
}
