using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boodle.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Boodle.Controllers
{
    public class SignupController : Controller
    {
        private readonly ISignupRepository repo;

        public SignupController(ISignupRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var signups = repo.GetAllSignups();

            return View(signups);
        }

        public IActionResult ViewSignup(int id)
        {
            var signup = repo.GetSignup(id);

            return View(signup);
        }

        public IActionResult ViewUpdateSignup(int id)
        {
            var signup = repo.GetSignup(id);

            return View(signup);
        }

        public IActionResult MakeBoxListSignup(int UsersID, int ListsID, string SignupDate, int quantity)
        {
            repo.MakeBoxListSignup(UsersID, ListsID, SignupDate, quantity);

            return RedirectToAction("Index", "BoxList");
        }

        public IActionResult UpdateShipDate(int SignupsID, string ShipDate)
        {
            repo.UpdateShipDate(SignupsID, ShipDate);

            return RedirectToAction("Index", "Boodler");
        }

        public IActionResult ViewSignupsByBoxList(int id)
        {
            var boxListSignups = repo.GetSignupsByList(id);

            return View(boxListSignups);
        }

        public IActionResult ViewSignupsByBoodler(int id)
        {
            var boodlerSignups = repo.GetSignupsByBoodler(id);

            return View(boodlerSignups);
        }
    }
}
