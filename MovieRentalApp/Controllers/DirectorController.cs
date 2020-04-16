using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorController(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public IActionResult index()
        {
            var directors = _directorRepository.GetAllWhitMovies();

            if (directors.Count() == 0) return View("Empty");

            return View(directors);
        }

        public IActionResult Update(int id)
        {
            var director = _directorRepository.GetById(id);

            if (director == null) return NotFound();

            return View(director);
        }

        [HttpPost]
        public IActionResult Update(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            _directorRepository.Update(director);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var viewModel = new CreateDirectorViewModel
            { Referer = Request.Headers["Referer"].ToString() };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateDirectorViewModel directorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(directorVM);
            }

            _directorRepository.Create(directorVM.Director);

            if (!String.IsNullOrEmpty(directorVM.Referer))
            {
                return Redirect(directorVM.Referer);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var director = _directorRepository.GetById(id);

            _directorRepository.Delete(director);

            return RedirectToAction("Index");
        }
    }
}