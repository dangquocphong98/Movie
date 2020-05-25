using Dapper;
using RoseClientF.DAL;
using RoseClientF.Models;
using RoseClientF.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoseClientF.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult AllMovie()
        {
            int PageIndex = 1;
            var TotalPage = 0;
          
            var parameter = new DynamicParameters();
            parameter.Add("@PageIndex", PageIndex);
            parameter.Add("@PageSize", 10);
            parameter.Add("@TotalPage",TotalPage,DbType.Int32,ParameterDirection.Output);
           var ls = DataAccess.LoadData<Movie>("dbo.LoadListMovieViewModel", parameter);
            
            return View(ls);
        }

        public ActionResult DetailMovie(int Id)
        {
            var param = new DynamicParameters();
            param.Add("@IdMovie", Id);
            var lsmodel = DataAccess.LoadData<MovieViewModel>("dbo.GetMovieById", param);
            var model = lsmodel.FirstOrDefault();

            var lsActor = DataAccess.LoadData<Actor>("dbo.GetListActorByIdMovie", param);
            ViewBag.ListActor = lsActor;

            return View(model);
        }
    }
}