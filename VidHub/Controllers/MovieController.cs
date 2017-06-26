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
            //Retrieve Movie Links
            var query = from m in MovieDE.MOVIEs
                        from l in MovieDE.MOVIE_LINK
                        from p in MovieDE.PATH_TYPE
                        from w in MovieDE.WEB_SITE
                        where m.MOVIE_ID == l.MOVIE_ID
                        where m.TITLE == MovieTitle
                        where p.PATH_ID == l.PATH_TYPE_ID
                        where p.PATH_TYPE1 == "Movie"
                        where l.SOURCE_WEB_SITE_ID == w.WEB_SITE_ID
                        select new
                        {
                            m.TITLE
                            ,m.MOVIE_POSTER_PATH
                            ,w.WEB_SITE_NAME
                            ,l.PATH
                        };

            if (query.Any() == false)
            {
                movie.PosterPath = "~/Images/Default.jpg"; //Default Path
            }
            else
            {
 
                movie.PosterPath = query.First().MOVIE_POSTER_PATH; 

                foreach(var m in query)
                {
                    movie.MovieLinkInfo.Add(new MovieLinkInfo(m.WEB_SITE_NAME, m.PATH) );

                }
            }


            return View(movie);
        }

        
    }
}