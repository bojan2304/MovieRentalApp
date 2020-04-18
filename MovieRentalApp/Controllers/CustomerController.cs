using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MovieRentalApp.Data.Interfaces;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMovieRepository _movieRepository;

        public CustomerController(ICustomerRepository customerRepository, IMovieRepository movieRepository)
        {
            _customerRepository = customerRepository;
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var customerVM = new List<CustomerViewModel>();

            var customers = _customerRepository.GetAll();

            if (customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    MovieCount = _movieRepository.Count(x => x.BorrowerId == customer.Id)
                });
            }

            return View(customerVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            customer.CreatedAt = DateAndTime.Now;
            _customerRepository.Create(customer);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _customerRepository.Update(customer);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);

            _customerRepository.Delete(customer);

            return RedirectToAction("Index");
        }
    }
}