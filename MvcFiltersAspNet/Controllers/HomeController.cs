using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFiltersAspNet.Filters;
using MvcFiltersAspNet.Models.EntityModel;

namespace MvcFiltersAspNet.Controllers
{
    [ActionFilter, ResultFilter, AuthorizationFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ExceptionFilter]
        public ActionResult Index2()
        {
            object sayi = 0;
            int deger = 100 / (int)sayi;
            //throw new Exception("Yetkisiz Giriş");

            return View();
        }
        [ExceptionFilter]
        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult ListLogs()
        {
            DatabaseContext db = new DatabaseContext();
            var logs = db.Logs.OrderByDescending(s => s.Date).ToList();

            return View(logs);
        }
        [HttpPost]
        public ActionResult ListLogs(DateTime startDate, DateTime endDate)
        {
            DatabaseContext db = new DatabaseContext();
            var query = from m in db.Logs
                        where m.Date > startDate
                        where m.Date < endDate
                        orderby m.Date descending select m;

            var list = query.ToList();
            return View(list);
        }
    }
}