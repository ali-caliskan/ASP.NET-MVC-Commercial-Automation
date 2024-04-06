using MvcOnlineTradeAutomation.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            //arama ürün adına göre 
            var k = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TrackingCode.Contains(p));
            }
            return View(k.ToList());
        }



        [HttpGet]
        public ActionResult YeniKargo()
        {
            //Random takip kodu oluşturma.
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "F", "E", "K", "M", "N" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10--> 3 1 2 1 2 1 
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(CargoDetail d)
        {
            c.CargoDetails.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            //p = "ABC34598NN";
            //Global.asax dosyasına gidip RouteConfig ayarı yapıcaz. routeconfig de id olduğuy için id yapıyoruz sorunu çözüyoruz
            var degerler = c.CargoFollows.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);
        }
    }
}