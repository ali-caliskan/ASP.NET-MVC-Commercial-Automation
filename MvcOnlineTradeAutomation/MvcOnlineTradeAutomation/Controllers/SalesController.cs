using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SalesMovements.ToList();
            return View(degerler);
        }

        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductsName,
                                               Value = x.ProductsID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Trades.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TradeName + " " + x.TradeSurname,
                                               Value = x.TradeID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurname,
                                               Value = x.PersonnelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SalesMovement s)
        {
            s.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductsName,
                                               Value = x.ProductsID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Trades.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TradeName + " " + x.TradeSurname,
                                               Value = x.TradeID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurname,
                                               Value = x.PersonnelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SalesMovements.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SalesMovement p)
        {
            var deger = c.SalesMovements.Find(p.SalesID);
            deger.TradeID = p.TradeID;
            deger.quantity = p.quantity;
            deger.Price = p.Price;
            deger.PersonnelID = p.PersonnelID;
            deger.Date = p.Date;
            deger.TotalAmount = p.TotalAmount;
            deger.ProductsID = p.ProductsID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SalesMovements.Where(x => x.SalesID == id).ToList();
            return View(degerler);
        }
    }
}