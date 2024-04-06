using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personnels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }


        [HttpPost]
        public ActionResult PersonelEkle(Personnel p)
        {
            //dosya yolu görsel
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Personnelİmage = "/Image/" + dosyaadi + uzanti;
            }
            c.Personnels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var prs = c.Personnels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personnel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Personnelİmage = "/Image/" + dosyaadi + uzanti;
            }

            var prsn = c.Personnels.Find(p.PersonnelID);
            prsn.PersonnelName = p.PersonnelName;
            prsn.PersonnelSurname = p.PersonnelSurname;
            prsn.Personnelİmage = p.Personnelİmage;
            prsn.DepartmentID = p.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personnels.ToList();
            return View(sorgu);
        }
    }
}