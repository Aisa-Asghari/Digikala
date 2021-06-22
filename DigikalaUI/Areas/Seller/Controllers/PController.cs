using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigikalaRepository.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigikalaUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class PController : Controller
    {
        private readonly IProductRepository Prepository;

        public PController(IProductRepository Prepository)
        {
            this.Prepository = Prepository;
        }
        //public IActionResult Create(DigikalaDataAccess.Entity.Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    Prepository.Create(product);
        //    return RedirectToAction("Index", "Home");
        //}
        //public IActionResult Delete(int id)
        //{
        //    Prepository.Delete(id);

        //    return RedirectToAction("Index", "Home");
        //}
        //public IActionResult Edit()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Edit(DigikalaDataAccess.Entity.Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    Prepository.Edit(product);
        //    return RedirectToAction("Index", "Home");
        //}
    }
}