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
    public class SütYumurtaController : Controller
    {
        private readonly FoodContext _context;

        public SütYumurtaController(FoodContext context)
        {
            _context = context;
        }

        // GET: SütYumurta
        public async Task<IActionResult> Index()
        {
            return View(await _context.SütVeYumurtaÜrünleri.ToListAsync());
        }

        // GET: SütYumurta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sütYumurta = await _context.SütVeYumurtaÜrünleri
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sütYumurta == null)
            {
                return NotFound();
            }

            return View(sütYumurta);
        }

        // GET: SütYumurta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SütYumurta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] SütYumurta sütYumurta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sütYumurta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sütYumurta);
        }

        // GET: SütYumurta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sütYumurta = await _context.SütVeYumurtaÜrünleri.SingleOrDefaultAsync(m => m.ID == id);
            if (sütYumurta == null)
            {
                return NotFound();
            }
            return View(sütYumurta);
        }

        // POST: SütYumurta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] SütYumurta sütYumurta)
        {
            if (id != sütYumurta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sütYumurta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SütYumurtaExists(sütYumurta.ID))
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
            return View(sütYumurta);
        }

        // GET: SütYumurta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sütYumurta = await _context.SütVeYumurtaÜrünleri
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sütYumurta == null)
            {
                return NotFound();
            }

            return View(sütYumurta);
        }

        // POST: SütYumurta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sütYumurta = await _context.SütVeYumurtaÜrünleri.SingleOrDefaultAsync(m => m.ID == id);
            _context.SütVeYumurtaÜrünleri.Remove(sütYumurta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SütYumurtaExists(int id)
        {
            return _context.SütVeYumurtaÜrünleri.Any(e => e.ID == id);
        }
    }
}
