using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidHub.Infrastructure;
using VidHub.Models;
namespace VidHub.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public MovieDbEntities MovieDE = new MovieDbEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieInfo(string MovieTitle)
        {
            MovieInfo movie = new MovieInfo(MovieTitle);
            return View(movie.RetrieveMovieInfo(MovieTitle));
        }
        
        public ActionResult DeleteCastMember(string Title ,int castMemberID)
        {
            return View("EditMovie", Title);

        }

        public ActionResult EditMovie (string MovieTitle = "Arival")
        {
            MovieInfo movie = new MovieInfo(MovieTitle);

            return View(movie.RetrieveMovieInfo(MovieTitle));
        }

        [HttpPost]
        public ActionResult EditMovie(MovieInfo Postedmovie)
        {
            Postedmovie.CreateUpdateMovie(Postedmovie);

            return View("EditMovie",Postedmovie.RetrieveMovieInfo(Postedmovie.Title) );
        }
    }
}