using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoseClientF.Models
{
    public class Movie
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Poster { get; set; }

        public string Showtimes { get; set; }
    }
}