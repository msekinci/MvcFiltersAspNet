using MvcFiltersAspNet.Models;
using MvcFiltersAspNet.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFiltersAspNet.Filters
{
    public class ResultFilter : FilterAttribute, IResultFilter
    {

        //View'ların oluşmadan ve oluştuktan sonraki anlarında çalışır

        DatabaseContext db = new DatabaseContext();

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            db.Logs.Add(new Models.Log()
            {
                Username = (filterContext.HttpContext.Session["user"] as SiteUser).Username,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Date = DateTime.Now,
                Report = "Result - OnActionExecuted"
            });
            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            db.Logs.Add(new Models.Log()
            {
                Username = (filterContext.HttpContext.Session["user"] as SiteUser).Username,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Date = DateTime.Now,
                Report = "Result - OnResultExecuting"
            });
            db.SaveChanges();
        }
    }
}