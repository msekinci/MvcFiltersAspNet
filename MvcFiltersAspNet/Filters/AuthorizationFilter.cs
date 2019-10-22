﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFiltersAspNet.Filters
{
    public class AuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/SignIn");
            }
        }
    }
}