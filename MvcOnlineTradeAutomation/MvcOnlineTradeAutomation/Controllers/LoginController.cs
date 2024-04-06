using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;
using System.Web.Security;

namespace MvcOnlineTradeAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Trade p)
        {
            c.Trades.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult TradeLogin1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult TradeLogin1(Trade p)
        {

            var bilgiler = c.Trades.FirstOrDefault(x => x.TradeMail == p.TradeMail && x.Tradepassword == p.Tradepassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.TradeMail, false);
                Session["TradeMail"] = bilgiler.TradeMail.ToString();
                return RedirectToAction("Index", "TradePanel");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                Session["UserName"] = bilgiler.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}