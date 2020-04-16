using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.ViewModels
{
    public class RentalViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
