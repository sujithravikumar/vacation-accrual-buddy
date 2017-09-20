﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacationAccrual.Models;

namespace VacationAccrual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListofPeriods = null;
            ViewBag.Accural = 0;
            ViewBag.Balance = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Result(string StartDate, string Accural, string Balance)
        {
            DateTime startDate = DateTime.Parse(StartDate);
            Double accural = String.IsNullOrWhiteSpace(Accural) ? 0 : Double.Parse(Accural);
            Double balance = String.IsNullOrWhiteSpace(Balance) ? 0 : Double.Parse(Balance);
            ViewBag.ListofPeriods = PayPeriod.GetPeriodList(startDate, accural, balance, 5);
            ViewBag.Accural = accural;
            ViewBag.Balance = balance;
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
