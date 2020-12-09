using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boodle.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Boodle.Controllers
{
    public class BoxListController : Controller
    {
        private readonly IBoxListRepository repo;

        public BoxListController(IBoxListRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var boxlists = repo.GetAllLists();

            return View(boxlists);
        }

        // Viewing an individual BoxList
        public IActionResult ViewBoxList(int id)
        {
            var boxlist = repo.GetBoxList(id);

            return View(boxlist);
        }

    }
}
