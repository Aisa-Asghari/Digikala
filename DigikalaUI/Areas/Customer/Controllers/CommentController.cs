using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigikalaDataAccess.Entity;
using DigikalaRepository.Comments;
using Microsoft.AspNetCore.Mvc;

namespace DigikalaUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository repository;

        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            if (!ModelState.IsValid)
                return View();

            comment.UserName = "Ice";
            repository.Add(comment);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var model = repository.GetAllByUser("Ice");
            return View(model);
        }
    }
}