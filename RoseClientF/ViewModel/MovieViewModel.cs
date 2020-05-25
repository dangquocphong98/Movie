using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoseClientF.ViewModel
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Actor { get; set; }
        public string Category { get; set; }
        public string Poster { get; set; }
        public string Summary { get; set; }
        public string Trailer { get; set; }
    }
}