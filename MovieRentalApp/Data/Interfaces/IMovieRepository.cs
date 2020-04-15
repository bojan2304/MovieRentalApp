using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetAllWhitDirector();
        IEnumerable<Movie> FindWhitDirector(Func<Movie, bool> predicate);
        IEnumerable<Movie> FindWhitDirectorAndCustomer(Func<Movie, bool> predicate);
    }
}
