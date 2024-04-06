using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;


namespace MvcOnlineTradeAutomation.Controllers
{
    public class TradeController : Controller
    {
        // GET: Trade
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Trades.Where(x => x.Status == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Trade p)
        {
            p.Status = true;
            c.Trades.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cr = c.Trades.Find(id);
            cr.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Trades.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Trade p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Trades.Find(p.TradeID);
            cari.TradeName = p.TradeName;
            cari.TradeSurname = p.TradeSurname;
            cari.TradeCity = p.TradeCity;
            cari.TradeMail = p.TradeMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SalesMovements.Where(x => x.TradeID == id).ToList();
            var cr = c.Trades.Where(x => x.TradeID == id).Select(y => y.TradeName + " " + y.TradeSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}