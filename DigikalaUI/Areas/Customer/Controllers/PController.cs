using DigikalaRepository.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigikalaUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class PController : Controller
    {
        private readonly IProductRepository Prepository;

        public PController(IProductRepository Prepository)
        {
            this.Prepository = Prepository;
        }

        public IActionResult All()
        {
            var model = Prepository.GetAll();
            return View(model);
        }
    }
}