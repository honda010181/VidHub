using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidHub.Models
{
    public class MovieModels
    {

    }
    public class Movie
    {
        public string Title { get; set; }
        public string PosterPath { get; set; }

        public Movie(string Title, string PosterPath)
        {
            this.Title = Title;
            this.PosterPath = PosterPath;
        }

    }
}