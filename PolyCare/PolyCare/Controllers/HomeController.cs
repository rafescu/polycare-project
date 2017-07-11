using PolyCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyCare.Controllers {
    public class HomeController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index() {

            var imagens = db.Carrousels.ToList();
            return View(imagens);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}