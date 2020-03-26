using Mall.DAL;
using Mall.Help;
using Mall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mall.Controllers
{
    public class ControllerBase : Controller
    {

        // GET: ControllerBase
        private Users _session;


        public Users SessionUser
        {
           
            get
            {
                try
                {
                    if (_session != null) //避免多次call
                        return _session;

                    if (!User.Identity.IsAuthenticated)
                        return null;
                    using (DataBase db = new DataBase())
                    {
                        _session = db.Database.SqlQuery<Users>($"Select * from Users where UserNo={User.Identity.Name} or UserName={User.Identity.Name}").FirstOrDefault();;
                    }
                    return _session;
                }
                catch (Exception ex)
                {
                    Logger.Error("登录异常", ex);
                    throw;
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.RealName = SessionUser.RealName;
                ViewBag.U = SessionUser.UserName;
                ViewBag.P = SessionUser.Password;
               
                string curPath = System.Web.HttpContext.Current.Request.Path;
                //foreach (var key in menus.Keys)
                //{
                //    List<ItemEntity> erji = menus[key];
                //    erji.ForEach(i =>
                //    {
                //        if (i.sPath.ToUpper() == curPath.ToUpper() || i.sShowPaths.ToUpper().Split('$').Contains(curPath.ToUpper()))
                //        {
                //            ViewBag.btns = btns[i.PKID];
                //        }
                //    });
                //}
                //ViewBag.Menus = menus;
                ViewBag.RealName = _session != null ? string.Format("{0}({1})", _session.RealName, _session.RealName) : "匿名用户";
            }
            base.OnActionExecuting(filterContext);
        }
    }
}