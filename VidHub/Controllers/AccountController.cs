using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using VidHub.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using VidHub.Infrastructure;
namespace VidHub.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
 
            ViewBag.returnUrl = returnUrl;
            return View();
 
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser user = await UserManager.FindAsync (details.Name, details.Password);
        //        if (user == null)
        //        {
        //            ModelState.AddModelError("","Invalid name or password");
        //        }
        //        else
        //        {
        //            ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user , DefaultAuthenticationTypes.ApplicationCookie);
        //            AuthManager.SignOut();
        //            AuthManager.SignIn(new AuthenticationProperties {IsPersistent = false} , ident);


        //            if (UserManager.IsInRole(user.Id, "Administrators"))
        //            {
        //                return Redirect("~/Admin");
        //            }
        //            else
        //            {
        //                if (returnUrl.Equals(""))
        //                {
        //                     return Redirect("~/Home");
        //                }
        //                else
        //                {
        //                    return Redirect(returnUrl);
        //                }

        //            }

        //        }
        //    }
        //    return View(details);
        //}
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel details)
        {
            if (ModelState.IsValid)
            {
                AppUser user =  UserManager.Find(details.Name, details.Password);
                if (user == null)
                {
                    //Using session variable to pass message into Referencing Model which then pass that to Layout view
                    HttpContext.Session["InvalidLoginInfo"] = "Invalid User ID or Password";



                    return Redirect("~/Home");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    
                    if (UserManager.IsInRole(user.Id, "Administrators"))
                    {
                        return Redirect("~/Admin");
                    }
                    else
                    {
                        return Redirect("~/Home");
                    }

                }
            }
            else
            {
                return Redirect("~/Home");
            }

        }
 
 
        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index","Home");
        }
        private IAuthenticationManager AuthManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
 
    }
}