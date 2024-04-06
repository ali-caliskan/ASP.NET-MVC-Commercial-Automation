using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTradeAutomation.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            //4 tane ekledik öbür kategoriler gözükmüyor.
            var degerler = c.Categories.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        //Sayfa yüklendiği zamanda çalışacak.
        public ActionResult KategoriEkle()
        {
            return View();
        }
        //Bir butona tıklandığında burayı çalıştır.
        [HttpPost]
        public ActionResult KategoriEkle(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult KategoriSil(int id)
        {
            var ktg = c.Categories.Find(id);
            c.Categories.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Categories.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Category k)
        {
            var ktgr = c.Categories.Find(k.CategoryID);
            ktgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Categoriess = new SelectList(c.Categories, "CategoryID", "CategoryName");
            cs.Productss = new SelectList(c.Products, "ProductsID", "ProductsName");
            return View(cs);
        }

        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Products
                               join y in c.Categories
                               on x.Category.CategoryID equals y.CategoryID
                               where x.Category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductsName,
                                   Value = x.ProductsID.ToString()
                               }).ToList();
            return Json(urunlistesi,JsonRequestBehavior.AllowGet);
        }
    }
}