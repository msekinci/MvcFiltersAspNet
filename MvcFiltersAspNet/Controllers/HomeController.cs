using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFiltersAspNet.Filters;

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
    }
}