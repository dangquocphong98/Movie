using RoseClientF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoseClientF.ViewModel
{
    public class SeatViewModel
    {
        public List<Seat> LsSeat { get; set; }
        public List<string> LsSeatBooked { get; set; }
    }
}