using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PeopleList.Data;
using PeopleList.Web.Models;

namespace PeopleList.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=People;Integrated Security=True";

        public IActionResult Index()
        {
            PeopleDBManager pdbm = new PeopleDBManager(_connectionString);
            var vm = new PeopleViewModel();

            vm.People = pdbm.GetPeople();

            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            var pbdm = new PeopleDBManager(_connectionString);
            pbdm.AddPeople(people);

            TempData["message"] = $"{people.Count} added successfully!";
            return Redirect("/home/index");
        }
    }
}
