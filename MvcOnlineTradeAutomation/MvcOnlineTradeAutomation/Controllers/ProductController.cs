using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;


namespace MvcOnlineTradeAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string p)
        {
            //arama ürün adına göre 
            var urunler = from x in c.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.ProductsName.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            //DropDownListFor İşlemi
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            //ViewBag Controller tarafından veri,değer taşımak için.
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Products.Find(id);
            deger.Status  = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;

            var urundeger = c.Products.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Product p)
        {
            var urn = c.Products.Find(p.ProductsID);
            urn.BuyPrice = p.BuyPrice;
            urn.Status = p.Status;
            urn.CategoryID = p.CategoryID;
            urn.Brand = p.Brand;
            urn.SalesPrice = p.SalesPrice;
            urn.Stock = p.Stock;
            urn.ProductsName = p.ProductsName;
            urn.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        

        public ActionResult UrunListesi()
        {
            var degerler = c.Products.ToList();
            return View(degerler);

        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {

            List<SelectListItem> deger3 = (from x in c.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurname,
                                               Value = x.PersonnelID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;

            var deger1 = c.Products.Find(id);
            
            ViewBag.dgr1 = deger1.ProductsID;
            ViewBag.dgr2 = deger1.SalesPrice;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SalesMovement p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Sales");
        }
    }
}