using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;

        public MovieController(IMovieRepository movieRepository, IDirectorRepository directorRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
        }

        public IActionResult Index(int? directorId, int? borrowerId)
        {
            if (directorId == null && borrowerId == null)
            {
                var movie = _movieRepository.GetAllWhitDirector();
                return CheckMovies(movie);
            }
            else if (directorId != null)
            {
                // filter by director id
                var director = _directorRepository.GetWhitMovies((int)directorId);

                if (director.Movies.Count() == 0)
                {
                    return View("EmptyDirector", director);
                }
                else
                {
                    return View(director.Movies);
                }
            }
            else if (borrowerId != null)
            {
                // filter by customer id
                var movies = _movieRepository.FindWhitDirectorAndCustomer(m => m.BorrowerId == borrowerId);
                // check customer movies
                return CheckMovies(movies);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IActionResult Create()
        {
            var movieVM = new MovieViewModel()
            {
                Directors = _directorRepository.GetAll()
            };
            return View(movieVM);
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel movieViewModel)
        {
            if (!ModelState.IsValid)
            {
                movieViewModel.Directors = _directorRepository.GetAll();
                return View(movieViewModel);
            }

            _movieRepository.Create(movieViewModel.Movie);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var movieVM = new MovieViewModel()
            {
                Movie = _movieRepository.GetById(id),
                Directors = _directorRepository.GetAll()
            };
            return View(movieVM);
        }

        [HttpPost]
        public IActionResult Update(MovieViewModel movieViewModel)
        {
            if (!ModelState.IsValid)
            {
                movieViewModel.Directors = _directorRepository.GetAll();
                return View(movieViewModel);
            }

            _movieRepository.Update(movieViewModel.Movie);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieRepository.GetById(id);

            _movieRepository.Delete(movie);

            return RedirectToAction("Index");
        }

        public IActionResult CheckMovies(IEnumerable<Movie> movie)
        {
            if (movie.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(movie);
            }
        }
    }
}