using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoseClientF.Models
{
    public class Tickets
    {
        public int IdMovie { get; set; }
        public string DateShow { get; set; }
        public string HourShow { get; set; }
        public string ListPosition { get; set; }
    }
}