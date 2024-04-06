using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Products.Where(x => x.ProductsID == 5).ToList();
            cs.Deger2 = c.Details.Where(y => y.DetailID == 1).ToList();
            return View(cs);
        }
    }
}