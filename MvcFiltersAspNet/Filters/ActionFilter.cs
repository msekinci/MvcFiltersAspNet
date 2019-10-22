using MvcFiltersAspNet.Models;
using MvcFiltersAspNet.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFiltersAspNet.Filters
{

    /*
     * FilterAttribute'dan kalıtılan class'lar Attribute olarak kullanılabilir.
     * IActionFilter : Class'ın başında ve sonunda işlem yapacağını belirtmek için kullanılır.
     */
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        DatabaseContext db = new DatabaseContext();

        //Action çalıştıktan sonra
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            db.Logs.Add(new Models.Log()
            {
                Username = (filterContext.HttpContext.Session["user"] as SiteUser).Username,
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Date = DateTime.Now,
                Report = "Action - OnActionExecuted"
            });
            db.SaveChanges();
        }


        //Action çalışmadan önce
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.Logs.Add(new Models.Log()
            {
                Username = (filterContext.HttpContext.Session["user"] as SiteUser).Username,
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Date = DateTime.Now,
                Report = "Action - OnActionExecuting"
            });
            db.SaveChanges();
        }
    }
}