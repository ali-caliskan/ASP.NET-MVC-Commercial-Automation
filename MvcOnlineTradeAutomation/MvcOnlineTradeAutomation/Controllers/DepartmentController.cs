using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;

namespace MvcOnlineTradeAutomation.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x => x.Status == true).ToList();
            return View(degerler);
        }

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DepartmanGetir",dpt);
        }
        
        public ActionResult DepartmanGuncelle(Department p)
        {
            var dept = c.Departments.Find(p.DepartmentID);
            dept.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personnels.Where(x => x.DepartmentID == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
       
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SalesMovements.Where(x => x.PersonnelID == id).ToList();
            var per = c.Personnels.Where(x => x.PersonnelID == id).Select(y => y.PersonnelName +" "+ y.PersonnelSurname).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}