using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data
{
    public class MovieRentalDbContext : DbContext
    {
        public MovieRentalDbContext(DbContextOptions<MovieRentalDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
}
