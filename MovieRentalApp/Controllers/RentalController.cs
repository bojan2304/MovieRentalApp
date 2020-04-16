using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class RentalController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalController(IMovieRepository movieRepository, ICustomerRepository customerRepository)
        {
            _movieRepository = movieRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var availableMovies = _movieRepository.FindWhitDirector(x => x.CustomerId == 0);
            if (availableMovies.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableMovies);
            }
        }

        public IActionResult RentMovie(int movieId)
        {
            var rentVM = new RentalViewModel()
            {
                Movie = _movieRepository.GetById(movieId),
                Customers = _customerRepository.GetAll()
            };
            return View(rentVM);
        }

        [HttpPost]
        public IActionResult LendBook(RentalViewModel rentalViewModel)
        {
            var movie = _movieRepository.GetById(rentalViewModel.Movie.Id);

            var customer = _customerRepository.GetById(rentalViewModel.Movie.CustomerId);

            movie.Customer = customer;

            _movieRepository.Update(movie);

            return RedirectToAction("Index");
        }
    }
}