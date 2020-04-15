using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data.Interfaces
{
    public interface IDirectorRepository : IRepository<Director>
    {
        IEnumerable<Director> GetAllWhitMovies();
        Director GetWhitMovies(int id);
    }
}
