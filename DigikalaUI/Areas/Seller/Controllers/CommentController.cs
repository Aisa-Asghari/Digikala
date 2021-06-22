using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigikalaDataAccess.Entity;
using DigikalaRepository.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigikalaUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository repository;

        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
    }
}