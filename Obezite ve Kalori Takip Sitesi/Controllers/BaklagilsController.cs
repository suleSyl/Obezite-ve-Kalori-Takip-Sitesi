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
    public class BaklagilsController : Controller
    {
        private readonly FoodContext _context;

        public BaklagilsController(FoodContext context)
        {
            _context = context;
        }

        // GET: Baklagils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baklagiller.ToListAsync());
        }

        // GET: Baklagils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baklagil = await _context.Baklagiller
                .SingleOrDefaultAsync(m => m.ID == id);
            if (baklagil == null)
            {
                return NotFound();
            }

            return View(baklagil);
        }

        // GET: Baklagils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baklagils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] Baklagil baklagil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baklagil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baklagil);
        }

        // GET: Baklagils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baklagil = await _context.Baklagiller.SingleOrDefaultAsync(m => m.ID == id);
            if (baklagil == null)
            {
                return NotFound();
            }
            return View(baklagil);
        }

        // POST: Baklagils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] Baklagil baklagil)
        {
            if (id != baklagil.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baklagil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaklagilExists(baklagil.ID))
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
            return View(baklagil);
        }

        // GET: Baklagils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baklagil = await _context.Baklagiller
                .SingleOrDefaultAsync(m => m.ID == id);
            if (baklagil == null)
            {
                return NotFound();
            }

            return View(baklagil);
        }

        // POST: Baklagils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baklagil = await _context.Baklagiller.SingleOrDefaultAsync(m => m.ID == id);
            _context.Baklagiller.Remove(baklagil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaklagilExists(int id)
        {
            return _context.Baklagiller.Any(e => e.ID == id);
        }
    }
}
