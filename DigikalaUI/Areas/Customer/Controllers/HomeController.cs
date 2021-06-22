using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigikalaDataAccess;
using DigikalaRepository.Users;
using DigikalaRepository.Products;
using Microsoft.AspNetCore.Mvc;
using DigikalaDataAccess.Context;
using DigikalaDataAccess.Entity;

namespace DigikalaUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUserRepository repository;

        public HomeController(IUserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexPv(User user)
        {
            var model = repository.GetUser(user);
            return View(model);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}