using MvcFiltersAspNet.Models;
using MvcFiltersAspNet.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFiltersAspNet.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        DatabaseContext db = new DatabaseContext();

        public void OnException(ExceptionContext filterContext)
        {
            string username = string.Empty;
            if (filterContext.HttpContext.Session["user"] != null)
            {
                db.Logs.Add(new Models.Log()
                {
                    Username = (filterContext.HttpContext.Session["user"] as SiteUser).Username,
                    ActionName = filterContext.RouteData.Values["action"].ToString(),
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    Date = DateTime.Now,
                    Report = "Error : " + filterContext.Exception.Message
                });
                db.SaveChanges();
            }

            

            filterContext.ExceptionHandled = true;
            filterContext.Controller.TempData["error"] = filterContext.Exception;
            filterContext.Result = new RedirectResult("/Login/Error");

        }
    }
}