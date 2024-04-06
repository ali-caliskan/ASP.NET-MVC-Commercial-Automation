using MvcOnlineTradeAutomation.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class TradePanelController : Controller
    {
        // GET: TradePanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["TradeMail"];


            var degerler = c.messages.Where(x => x.buyer == mail).ToList();
            ViewBag.m = mail;

            var mailid = c.Trades.Where(x => x.TradeMail == mail).Select(y => y.TradeID).FirstOrDefault();
            ViewBag.mid = mailid;

            var toplamsatis = c.SalesMovements.Where(x => x.TradeID == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;

            var toplamtutar = c.SalesMovements.Where(x => x.TradeID == mailid).Sum(y => y.TotalAmount);
            ViewBag.toplamtutar = toplamtutar;

            var toplamurunsayisi = c.SalesMovements.Where(x => x.TradeID == mailid).Sum(y => y.quantity);
            ViewBag.toplamurunsayisi = toplamurunsayisi;

            var adsoyad = c.Trades.Where(x => x.TradeMail == mail).Select(y => y.TradeName + " " + y.TradeSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;


            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["TradeMail"];
            var id = c.Trades.Where(x => x.TradeMail == mail.ToString()).Select(y => y.TradeID).FirstOrDefault();
            var degerler = c.SalesMovements.Where(x => x.TradeID == id).ToList();
            return View(degerler);
        }


        [Authorize]
        public ActionResult GelenMesajlar()
        {
            //mail değişkeni sisteme giriş yapan cari mail tutacak.
            var mail = (string)Session["TradeMail"];
            var mesajlar = c.messages.Where(x => x.buyer == mail).OrderByDescending(x => x.MessageID).ToList();
            var gelensayisi = c.messages.Count(x => x.buyer == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }

        [Authorize]
        public ActionResult GidenMesajlar()
        {
            //mail değişkeni sisteme giriş yapan cari mail tutacak.
            var mail = (string)Session["TradeMail"];
            var mesajlar = c.messages.Where(x => x.Sender == mail).OrderByDescending(z => z.MessageID).ToList();
            var gelensayisi = c.messages.Count(x => x.buyer == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.messages.Where(x => x.MessageID == id).ToList();
            var mail = (string)Session["TradeMail"];
            var gelensayisi = c.messages.Count(x => x.buyer == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["TradeMail"];
            var gelensayisi = c.messages.Count(x => x.buyer == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(message m)
        {
            var mail = (string)Session["TradeMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            c.messages.Add(m);
            c.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {

            var k = from x in c.CargoDetails select x;
            k = k.Where(y => y.TrackingCode.Contains(p));
            return View(k.ToList());
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.CargoFollows.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();//istekleri terket
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["TradeMail"];
            var id = c.Trades.Where(x => x.TradeMail == mail).Select(y => y.TradeID).FirstOrDefault();
            var caribul = c.Trades.Find(id);
            return PartialView("Partial1",caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(veriler);
        }

        public ActionResult CariBilgiGuncelle(Trade cr)
        {
            var cari = c.Trades.Find(cr.TradeID);
            cari.TradeName = cr.TradeName;
            cari.TradeSurname = cr.TradeSurname;
            cari.Tradepassword = cr.Tradepassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}