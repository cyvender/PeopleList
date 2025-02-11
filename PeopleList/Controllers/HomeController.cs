using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PeopleList.Models;

namespace PeopleList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
