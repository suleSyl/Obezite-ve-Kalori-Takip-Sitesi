using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obezite_ve_Kalori_Takip_Sitesi.Data;
using Obezite_ve_Kalori_Takip_Sitesi.Models;

namespace Obezite_ve_Kalori_Takip_Sitesi.Controllers
{
    public class MyViewModelsController : Controller
    {
        private readonly FoodContext _context;

        public MyViewModelsController(FoodContext context)
        {
            _context = context;
        }

        // GET: MyViewModels
        public IActionResult Index()
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

        // GET: MyViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myViewModel = await _context.MyViewModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (myViewModel == null)
            {
                return NotFound();
            }

            return View(myViewModel);
        }

        // GET: MyViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] MyViewModel myViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myViewModel);
        }

        // GET: MyViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myViewModel = await _context.MyViewModel.SingleOrDefaultAsync(m => m.ID == id);
            if (myViewModel == null)
            {
                return NotFound();
            }
            return View(myViewModel);
        }

        // POST: MyViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] MyViewModel myViewModel)
        {
            if (id != myViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyViewModelExists(myViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(myViewModel);
        }

        // GET: MyViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myViewModel = await _context.MyViewModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (myViewModel == null)
            {
                return NotFound();
            }

            return View(myViewModel);
        }

        // POST: MyViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myViewModel = await _context.MyViewModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.MyViewModel.Remove(myViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyViewModelExists(int id)
        {
            return _context.MyViewModel.Any(e => e.ID == id);
        }
    }
}
