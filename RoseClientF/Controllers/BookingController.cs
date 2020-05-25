using Dapper;
using RoseClientF.DAL;
using RoseClientF.Helper;
using RoseClientF.Models;
using RoseClientF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseClientF.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index(int Id)
        {
            Session["idMovie"] = Id;
            
            var param = new DynamicParameters();
            param.Add("@IdMovie", Id);
            var lsHour = DataAccess.LoadData<Hour>("dbo.GetHourForMovie", param);
            ViewBag.LsHourMovie = lsHour;
            var ls = DataAccess.LoadData<Seat>("dbo.LoadSeatInRoom");

            var Lsmovie = DataAccess.LoadData<Movie>("dbo.GetMovie",param);
            var movie = Lsmovie.FirstOrDefault();
            ViewBag.NameMovie = movie.Name;
            var dateshow = movie.Showtimes;
            DayOfWeek day;
            if (Enum.TryParse<DayOfWeek>(dateshow, out day))
            {
                DateTime dt = DateTime.Now.StartOfWeek(day);
                if (DateTime.Now.ToString("MM/dd/yyyy") == dt.ToString("MM/dd/yyyy"))
                {

                }
                else if (DateTime.Now > dt)
                {
                    dt = dt.AddDays(7);
                }
                ViewBag.DateSee = dt.ToString("dd/MM/yyyy");
            }
            return View(ls);
        }

        public ActionResult GetListSeatBooked(string DateSee, string HourSee)
        {
            var param = new DynamicParameters();
            param.Add("@IdMovie", Session["idMovie"]);
            param.Add("@DateShow", DateSee);
            param.Add("@HourShow", HourSee);
            SeatViewModel model = new SeatViewModel();
            model.LsSeatBooked = new List<string>();
            var ls = DataAccess.LoadData<Seat>("dbo.LoadSeatInRoom");
            var lsBooked = DataAccess.LoadData<string>("dbo.GetSeatBooked",param).FirstOrDefault();

            model.LsSeat = ls;
            if (lsBooked != null)
            {
                var lsSeatBooked_A = lsBooked.Split(',').ToList();
                foreach (var item in lsSeatBooked_A)
                {
                    model.LsSeatBooked.Add(item);
                }
            }
            
            //model.LsSeatBooked = lsSeatBooked_A;
           
            return PartialView("_ListSeatBooked", model);
        }
        
        public ActionResult Booking(Tickets model)
        {
            string rs = "";
            DynamicParameters parma = new DynamicParameters();
            parma.Add("@IdMovie", Session["idMovie"]);
            parma.Add("@IdUser", 1);
            parma.Add("@DateShow",model.DateShow);
            parma.Add("@HourShow", model.HourShow);
            parma.Add("@ListPosition", model.ListPosition);

            if (DataAccess.SaveData("dbo.AddTickets", parma) > 0)
            {
                rs = "Success";
            }
            else rs = "Fail";
            return Json(rs);
        }

        
    }
}