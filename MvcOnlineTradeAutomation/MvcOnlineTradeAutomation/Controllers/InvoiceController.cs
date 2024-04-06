using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Invoices.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Invoice f)
        {
            c.Invoices.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Invoices.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Invoice f)
        {
            var fatura = c.Invoices.Find(f.InvoiceID);
            fatura.InvoiceSeriNo = f.InvoiceSeriNo;
            fatura.InvoiceSıraNo = f.InvoiceSıraNo;
            fatura.Clock = f.Clock;
            fatura.Date = f.Date;
            fatura.Deliveredby = f.Deliveredby;
            fatura.Receiver = f.Receiver;
            fatura.TaxOffice = f.TaxOffice;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.InvoicePens.Where(x => x.Invoiceid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(InvoicePen p)
        {
            c.InvoicePens.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Invoices.ToList();
            cs.deger2 = c.InvoicePens.ToList();
            return View(cs);
        }





        public ActionResult FaturaKaydet(string InvoiceSeriNo, string InvoiceSıraNo, DateTime Date
            , string TaxOffice, string Clock, string Deliveredby, string Receiver, string Total, InvoicePen[] kalemler)
        {
            Invoice f = new Invoice();
            f.InvoiceSeriNo = InvoiceSeriNo;
            f.InvoiceSıraNo = InvoiceSıraNo;
            f.Date = Date;
            f.TaxOffice = TaxOffice;
            f.Clock = Clock;
            f.Deliveredby = Deliveredby;
            f.Receiver = Receiver;
            f.Total = decimal.Parse(Total);
            c.Invoices.Add(f);
            foreach (var x in kalemler)
            {
                InvoicePen fk = new InvoicePen();
                fk.Description = x.Description;
                fk.UnitPrice = x.UnitPrice;
                fk.Invoiceid = x.Invoiceid;
                fk.Quantity = x.Quantity;
                fk.Amount = x.Amount;
                c.InvoicePens.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}