using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFinder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pet(long id = -1)
        {
            if (id < 0)
            {
                return View("Index");
            }

            Code.DBclasses.Pet pet = Code.DBfunctions.getPetById(id);
            if (pet == null)
            {
                ViewBag.Error = "Питомец #" + id.ToString() + " не найден";
            }

            ViewBag.Message = "Pet ID is " + id.ToString();

            return View(pet);
        }
    }
}