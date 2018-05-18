using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Obezite_ve_Kalori_Takip_Sitesi.Models;

namespace Obezite_ve_Kalori_Takip_Sitesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calories()
        {
            ViewData["Message"] = "Kalori değerleri sayfası";

            return View();
        }

        public IActionResult HowMany()
        {
            ViewData["Message"] = "Kaç Kalori aldım sayfası";

            return View();
        }

        public IActionResult Calculations()
        {
            ViewData["Message"] = "Hesaplamalar sayfası";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
