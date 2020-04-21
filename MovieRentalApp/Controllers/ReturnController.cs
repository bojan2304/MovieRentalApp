using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Data.Interfaces;

namespace MovieRentalApp.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IMovieRepository movieRepository, ICustomerRepository customerRepository)
        {
            _movieRepository = movieRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            // rented movies
            var rentedMovies = _movieRepository.FindWhitDirectorAndCustomer(x => x.BorrowerId != null);

            if (rentedMovies == null || rentedMovies.ToList().Count() == 0)
            {
                return View("Empty");
            }
            return View(rentedMovies);
        }

        public IActionResult ReturnMovie(int movieId)
        {
            var movie = _movieRepository.GetById(movieId);
            movie.Borrower = null;
            movie.BorrowerId = null;

            _movieRepository.Update(movie);

            return RedirectToAction("Index");
        }
    }
}