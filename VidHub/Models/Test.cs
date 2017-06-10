using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace VidHub.Models
{
    public class Test : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //base.OnResultExecuted(filterContext);
            filterContext.Controller.ViewBag.test = new Random() ;
 
        }
    }
}