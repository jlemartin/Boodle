using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boodle.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Boodle.Controllers
{
    public class BoodlerController : Controller
    {
        private readonly IBoodlerRepository repo;

        public BoodlerController(IBoodlerRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var boodlers = repo.GetAllBoodlers();

            return View(boodlers);
        }

        public IActionResult ViewBoodler(int id)
        {
            var boodler = repo.GetBoodler(id);

            return View(boodler);
        }

        // Get Box List Contacts
        public IActionResult ViewBoxListContacts()
        {
            var boodlers = repo.GetBoxListContacts();

            return View(boodlers);
        }

        public IActionResult ViewUpdateMultipleShipments(int id)
        {
            var boodler = repo.GetBoodler(id);

            return View(boodler);
        }
    }
}
