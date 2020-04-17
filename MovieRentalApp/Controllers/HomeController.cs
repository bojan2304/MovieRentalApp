using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IMovieRepository movieRepository, IDirectorRepository directorRepository, ICustomerRepository customerRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var homeVM = new HomeViewModel()
            {
                DirectorCount = _directorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                MovieCount = _movieRepository.Count(x => true),
                RentMovieCount = _movieRepository.Count(x => x.Borrower != null)
            };

            return View(homeVM);
        }
    }
}
