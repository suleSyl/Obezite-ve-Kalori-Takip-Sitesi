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
    public class MeyvesController : Controller
    {
        private readonly FoodContext _context;

        public MeyvesController(FoodContext context)
        {
            _context = context;
        }

        // GET: Meyves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meyveler.ToListAsync());
        }

        // GET: Meyves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meyve = await _context.Meyveler
                .SingleOrDefaultAsync(m => m.ID == id);
            if (meyve == null)
            {
                return NotFound();
            }

            return View(meyve);
        }

        // GET: Meyves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meyves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] Meyve meyve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meyve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meyve);
        }

        // GET: Meyves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meyve = await _context.Meyveler.SingleOrDefaultAsync(m => m.ID == id);
            if (meyve == null)
            {
                return NotFound();
            }
            return View(meyve);
        }

        // POST: Meyves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] Meyve meyve)
        {
            if (id != meyve.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meyve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeyveExists(meyve.ID))
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
            return View(meyve);
        }

        // GET: Meyves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meyve = await _context.Meyveler
                .SingleOrDefaultAsync(m => m.ID == id);
            if (meyve == null)
            {
                return NotFound();
            }

            return View(meyve);
        }

        // POST: Meyves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meyve = await _context.Meyveler.SingleOrDefaultAsync(m => m.ID == id);
            _context.Meyveler.Remove(meyve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeyveExists(int id)
        {
            return _context.Meyveler.Any(e => e.ID == id);
        }
    }
}
