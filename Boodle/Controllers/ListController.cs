using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boodle.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Boodle.Controllers
{
    public class ListController : Controller
    {
        private readonly IListRepository repo;

        public ListController(IListRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var lists = repo.GetAllLists();

            return View(lists);
        }
    }
}
