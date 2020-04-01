using Mall.DAL;
using Mall.Models;
using PagedList;
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
        public ActionResult FootPrintList(int page=1)
        {
            List<Footprint> footPrints = new List<Footprint>();
            using (DataBase db=new DataBase())
            {
                footPrints = db.FootprintDAL.Where(x => x.UserID == SessionUser.PKID&&x.Status==1).OrderByDescending(x => x.Id).ToList();
            }
            return View(footPrints.ToPagedList(page, 50));
        }
        public ActionResult ClearFoot(int Id)
        {
            using (DataBase db = new DataBase())
            {
                Footprint footPrint = new Footprint();
                footPrint = db.FootprintDAL.Where(x => x.Id == Id).FirstOrDefault();
                footPrint.Status = 0;
                db.SaveChanges();
            }
            return RedirectToAction("FootPrintList", "Consumer");
        }
    }
}