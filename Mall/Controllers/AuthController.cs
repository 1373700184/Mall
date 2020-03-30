using Mall.DAL;
using Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mall.Controllers
{
    public class AuthController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginPost model)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginIn(LoginPost model)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            if (ModelState.IsValid)
            {
                string srt = LogTo(model);
                if (srt == "")
                {
                    FormsAuthentication.SetAuthCookie(model.user, true);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.user, DateTime.Now, DateTime.Now.AddMinutes(60), false, "");
                    //数据加密
                    string enyTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enyTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Error = srt;
                }              

            }
            return RedirectToAction("Login",model);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string LogTo(LoginPost model)
        {
            string S = "";
            using (DataBase db = new DataBase())
            {
                Users user = null;
                user = db.UsersDAL.Where(x=>x.UserName==model.user||x.UserNo==model.user).FirstOrDefault();
                if (user == null)
                {
                    S = "登录账号错误";
                }
                if (user != null&& user.Password!=model.pwd)
                {
                    S = "密码错误";
                }
            }
               

            return S;
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}