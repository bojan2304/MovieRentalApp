using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.ViewModels
{
    public class HomeViewModel
    {
        public int CustomerCount { get; set; }
        public int DirectorCount { get; set; }
        public int MovieCount { get; set; }
        public int LendMovieCount { get; set; }
    }
}
