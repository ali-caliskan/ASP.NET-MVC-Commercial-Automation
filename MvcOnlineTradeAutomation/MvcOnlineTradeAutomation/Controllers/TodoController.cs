﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTradeAutomation.Models.Class;

namespace MvcOnlineTradeAutomation.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Trades.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Categories.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in c.Trades select x.TradeCity).Distinct().Count().ToString();
            ViewBag.d4 = deger4;



            var yapilacaklar = c.todos.ToList();
            return View(yapilacaklar);
        }
    }
}