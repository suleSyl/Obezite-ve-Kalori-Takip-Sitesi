using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obezite_ve_Kalori_Takip_Sitesi.Data;
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
            var model = new MyViewModel();
            DbInitializer.setGenelÜrünler();
            model.baklagilList = DbInitializer.bütünGıdalar.baklagilList;
            model.denizÜrünüList = DbInitializer.bütünGıdalar.denizÜrünüList;
            model.etList = DbInitializer.bütünGıdalar.etList;
            model.kuruyemişList = DbInitializer.bütünGıdalar.kuruyemişList;
            model.meyveList = DbInitializer.bütünGıdalar.meyveList;
            model.sebzeList = DbInitializer.bütünGıdalar.sebzeList;
            model.sütYumurtaList = DbInitializer.bütünGıdalar.sütYumurtaList;
            model.yağList = DbInitializer.bütünGıdalar.yağList;

            return View(model);
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
