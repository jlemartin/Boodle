using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boodle.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Boodle.Controllers
{
    public class TheNumbersController : Controller
    {
        private readonly ITheNumbersRepository repo;

        public TheNumbersController(ITheNumbersRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var theNumbers = repo.GetTheNumbers();

            return View(theNumbers);
        }
    }
}
