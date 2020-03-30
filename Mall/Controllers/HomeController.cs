using Mall.DAL;
using Mall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mall.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            if (SessionUser != null)
            {
                ViewBag.UserName = SessionUser.UserName;
            }
            return View();
        }

        public JsonResult LogFoot(string pageURL,string pageTitle)
        {
            List<Footprint> footprints = null;
            if (SessionUser != null)
            {
                using (DataBase db = new DataBase())
                {
                    footprints = db.Database.SqlQuery<Footprint>("Select Top 6 * from Footprint Order by Id desc ").ToList();
                    Footprint footprint = new Footprint();
                    footprint.Url = pageURL;
                    footprint.UserID = SessionUser.PKID;
                    footprint.Title = pageTitle;
                    footprint.DateCreate = DateTime.Now;
                    footprint.Status = 1;
                    db.FootprintDAL.Add(footprint);
                    db.SaveChanges();
                    
                }
                
            }
            
            return Json(footprints);
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}