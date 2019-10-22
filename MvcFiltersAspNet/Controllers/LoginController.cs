using MvcFiltersAspNet.Models;
using MvcFiltersAspNet.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFiltersAspNet.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View(new SiteUser());
        }

        [HttpPost]
        public ActionResult SignIn(SiteUser model)
        {
            DatabaseContext db = new DatabaseContext();
            SiteUser user = db.SiteUsers.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                return View(model);
            }
            Session["user"] = user;
            return RedirectToAction("Index", "Home");            
        }

        // GET: Error
        public ActionResult Error()
        {
            if (TempData["error"] == null)
                return RedirectToAction("Index", "Home");
            Exception model = TempData["error"] as Exception;
            return View(model);
        }

    }
}