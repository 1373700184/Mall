using Mall.DAL;
using Mall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mall.Controllers
{
    public class ConsumerController : ControllerBase
    {
        // GET: Consumer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FootPrintList()
        {
            List<Footprint> footPrints = new List<Footprint>();
            using (DataBase db=new DataBase())
            {
                footPrints = db.FootprintDAL.Where(x => x.UserID == SessionUser.PKID).ToList();
            }
            return View(footPrints);
        }
    }
}