using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidHub.Models;
using VidHub.Infrastructure;
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


        private List<MOVIE> GetFeatureMovieList()
        {

            MovieDbEntities mv = new MovieDbEntities();

            return mv.MOVIEs.Take(10).ToList<MOVIE>();

            //List<Movie_info> movieList = new List<Movie_info>();

            //Movie_info m1 = new Movie_info("Arival", "~/Images/Arival.jpg");
            //Movie_info m2 = new Movie_info("Chucky", "~/Images/Chucky.jpg");
            //Movie_info m3 = new Movie_info("Guardian Of Russia", "~/Images/GuardianOfRussia.jpg");
            //Movie_info m4 = new Movie_info("Moon Light", "~/Images/MoonLight.jpg");
            //Movie_info m5 = new Movie_info("Recovery", "~/Images/Recovery.jpg");
            //Movie_info m6 = new Movie_info("Sky Fall", "~/Images/SkyFall.jpg");
            //Movie_info m7 = new Movie_info("StarWars", "~/Images/StarWars.jpg");
            //Movie_info m8 = new Movie_info("The Magnificient 7", "~/Images/TheMagnificient7.jpg");
            //Movie_info m9 = new Movie_info("The Punisher", "~/Images/ThePunisher.jpg");
            //Movie_info m10 = new Movie_info("Under World", "~/Images/UnderWorld.jpg");


            //movieList.Add(m1);
            //movieList.Add(m2);
            //movieList.Add(m3);
            //movieList.Add(m4);
            //movieList.Add(m5);
            //movieList.Add(m6);
            //movieList.Add(m7);
            //movieList.Add(m8);
            //movieList.Add(m9);
            //movieList.Add(m10);
            //movieList.Add("~/Images/Arival.jpg");
            //movieList.Add("~/Images/Chucky.jpg");

            //movieList.Add("~/Images/GuardianOfRussia.jpg");
            //movieList.Add("~/Images/MoonLight.jpg");

            //movieList.Add("~/Images/Recovery.jpg");
            //movieList.Add("~/Images/SkyFall.jpg");

            //movieList.Add("~/Images/StarWars.jpg");
            //movieList.Add("~/Images/TheMagnificient7.jpg");

            //movieList.Add("~/Images/ThePunisher.jpg");
            //movieList.Add("~/Images/UnderWorld.jpg");
            //return mv;
        }
        
    }
}