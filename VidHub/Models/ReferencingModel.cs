using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidHub.Models;
namespace VidHub.Models
{

    //This class is created to pass data between views
    //This class must be regiestered in the global aspx
    // Or create a controler to inherit this class and other controllers will inherit from it to create the global view bag effect
    public  class GlobalReferencingModel : ActionFilterAttribute 
    {
        public LoginModel LoginModel { get; set; }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.InvalidLoginInfo = HttpContext.Current.Session["InvalidLoginInfo"];

            filterContext.Controller.ViewBag.FeatureMovieList = GetFeatureMovieList();
        }


        private List<string> GetFeatureMovieList()
        {
            List<string> movieList = new List<string>();


            movieList.Add("~/Images/Arival.jpg");
            movieList.Add("~/Images/Chucky.jpg");

            movieList.Add("~/Images/GuardianOfRussia.jpg");
            movieList.Add("~/Images/MoonLight.jpg");

            movieList.Add("~/Images/Recovery.jpg");
            movieList.Add("~/Images/SkyFall.jpg");

            movieList.Add("~/Images/StarWars.jpg");
            movieList.Add("~/Images/TheMagnificient7.jpg");

            movieList.Add("~/Images/ThePunisher.jpg");
            movieList.Add("~/Images/UnderWorld.jpg");
            return movieList;
        }
        
    }
}