using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;
namespace MvcOnlineTradeAutomation.Controllers
{
    public class StatisticDefaultController : Controller
    {
        // GET: StatisticDefault
        Context c = new Context();
        public ActionResult Index()
        {
            //Linq Sorgular

            //toplam cari 
            var deger1 = c.Trades.Count().ToString();
            ViewBag.d1 = deger1;

            //ürün sayısı
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;

            //personel sayısı
            var deger3 = c.Personnels.Count().ToString();
            ViewBag.d3 = deger3;

            //kategori sayısı
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;

            //stok sayısı
            var deger5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = deger5;

            //marka sayısı
            var deger6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            //kritik seviye(stok 20 altına düşerse)
            var deger7 = c.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = deger7;

            //max fiyatlı ürün
            var deger8 = (from x in c.Products orderby x.SalesPrice descending select x.ProductsName).FirstOrDefault();
            ViewBag.d8 = deger8;

            //min fiyatlı ürün
            var deger9 = (from x in c.Products orderby x.SalesPrice ascending select x.ProductsName).FirstOrDefault();
            ViewBag.d9 = deger9;

            //buzdolabı sayısı çekiyoruz çünkü bürün bizde fazla!
            var deger10 = c.Products.Count(x => x.ProductsName=="Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            //laptop sayısı
            var deger11 = c.Products.Count(x => x.ProductsName == "Laptop").ToString();
            ViewBag.d11 = deger11;

            //max marka sayısı
            var deger12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;


            //en çok satan 
            var deger13 =c.Products.Where(u =>u.ProductsID == (c.SalesMovements.GroupBy(x =>
            x.ProductsID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k =>k.ProductsName).FirstOrDefault();
            ViewBag.d13 = deger13;


            //kasadaki tutar
            var deger14 = c.SalesMovements.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = deger14;

            //bugünkü satışlar
            DateTime bugun = DateTime.Today;
            var deger15 = c.SalesMovements.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = deger15;

            //bugünkü kasa
            var deger16 = c.SalesMovements.Where(x => x.Date == bugun).Sum(y => (decimal?)y.TotalAmount).ToString();
            ViewBag.d16 = deger16;

            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Trades
                        group x by x.TradeCity into g
                        select new ClassGroup
                        {
                            Şehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }

        //nereye çağırırsak ilgili değerler oraya gelicek.
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personnels
                         group x by x.Department.DepartmentName into g
                         select new ClassGroup2
                         {
                             Department = g.Key,
                             number = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Trades.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Products.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Products
                         group x by x.Brand into g
                         select new ClassGroup3
                         {
                             brand = g.Key,
                             number = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}