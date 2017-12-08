using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidHub.Infrastructure;
using VidHub.Models;

namespace VidHub.Controllers
{        
    
    [Authorize(Roles = "Administrators")]
    public class MovieController : Controller
    {
        // GET: Movie
        public MovieDbEntities MovieDE = new MovieDbEntities();
        public string EditMode = "Edit"; //Edit mode will add one blank movie link object
        public string ViewMode = "View";
        public string AddMode = "Add";

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult MovieInfo(string MovieTitle)
        {
            MovieInfo movie = new MovieInfo(MovieTitle);
            return View(movie.RetrieveMovieInfo(MovieTitle, ViewMode));
        }

        public ActionResult EditMovie (string MovieTitle)
        {
            MovieInfo movie = new MovieInfo(MovieTitle);
            return View(movie.RetrieveMovieInfo(MovieTitle, EditMode));
        }
 


        [HttpPost]
        public ActionResult EditMovie(MovieInfo Postedmovie)
        {
            //fe
            //Book book = FetchYourBookFromTheId(selectedBookId);
            //var data = GetDatasAboutBookSelected(book);
            //ViewBag.Data = data;
            int selectedIndexGenre ;
            string selectGenre = Request.Form["DDLGenre"].ToString();
            
            Int32.TryParse(selectGenre,out selectedIndexGenre);

            Postedmovie.selectedDropDownID = selectedIndexGenre;
            Postedmovie.UserName = User.Identity.Name;
            Postedmovie.CreateUpdateMovie(Postedmovie);
            MovieInfo movie = new MovieInfo(Postedmovie.Title);
            return View("EditMovie", movie.RetrieveMovieInfo(movie.Title, EditMode));

        }

        //Todo authorized only
        public ActionResult DeletePersonRole(string movieTitle, int PersonRoleID)
        {
            MovieInfo movie = new MovieInfo(movieTitle);
            if (PersonRoleID != 0)
            {
                movie.DeletePersonRole(PersonRoleID);
            }


            return View("EditMovie", movie.RetrieveMovieInfo(movieTitle, EditMode));
        }

        public ActionResult DeleteMovieLink(string movieTitle, int movieLinkID)
        {

            MovieInfo movie = new MovieInfo(movieTitle);

            if (movieLinkID != 0)
            {
                movie.DeleteMovieLink(movieLinkID);
            }
            return View("EditMovie", movie.RetrieveMovieInfo(movieTitle, EditMode));
        }

        public ActionResult DeleteMovieGenre (string movieTitle, int movieGenreID)
        {
            MovieInfo movie = new MovieInfo(movieTitle);

            if (movieGenreID != 0)
            {
                movie.DeleteMovieGenre(movieGenreID);
            }
            return View("EditMovie", movie.RetrieveMovieInfo(movieTitle, EditMode));
        }

    }
}