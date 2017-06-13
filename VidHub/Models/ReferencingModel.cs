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


        private List<Movie> GetFeatureMovieList()
        {
            List<Movie> movieList = new List<Movie>();

            Movie m1 = new Movie("Arival", "~/Images/Arival.jpg");
            Movie m2 = new Movie("Chucky", "~/Images/Chucky.jpg");
            Movie m3 = new Movie("Guardian Of Russia", "~/Images/GuardianOfRussia.jpg");
            Movie m4 = new Movie("Moon Light", "~/Images/MoonLight.jpg");
            Movie m5 = new Movie("Recovery", "~/Images/Recovery.jpg");
            Movie m6 = new Movie("Sky Fall", "~/Images/SkyFall.jpg");
            Movie m7 = new Movie("StarWars", "~/Images/StarWars.jpg");
            Movie m8 = new Movie("The Magnificient 7", "~/Images/TheMagnificient7.jpg");
            Movie m9 = new Movie("The Punisher", "~/Images/ThePunisher.jpg");
            Movie m10 = new Movie("Under World", "~/Images/UnderWorld.jpg");


            movieList.Add(m1);
            movieList.Add(m2);
            movieList.Add(m3);
            movieList.Add(m4);
            movieList.Add(m5);
            movieList.Add(m6);
            movieList.Add(m7);
            movieList.Add(m8);
            movieList.Add(m9);
            movieList.Add(m10);
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
            return movieList;
        }
        
    }
}