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
    public class SebzesController : Controller
    {
        private readonly FoodContext _context;

        public SebzesController(FoodContext context)
        {
            _context = context;
        }

        // GET: Sebzes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sebzeler.ToListAsync());
        }

        // GET: Sebzes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sebze = await _context.Sebzeler
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sebze == null)
            {
                return NotFound();
            }

            return View(sebze);
        }

        // GET: Sebzes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sebzes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] Sebze sebze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sebze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sebze);
        }

        // GET: Sebzes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sebze = await _context.Sebzeler.SingleOrDefaultAsync(m => m.ID == id);
            if (sebze == null)
            {
                return NotFound();
            }
            return View(sebze);
        }

        // POST: Sebzes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] Sebze sebze)
        {
            if (id != sebze.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sebze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SebzeExists(sebze.ID))
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
            return View(sebze);
        }

        // GET: Sebzes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sebze = await _context.Sebzeler
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sebze == null)
            {
                return NotFound();
            }

            return View(sebze);
        }

        // POST: Sebzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sebze = await _context.Sebzeler.SingleOrDefaultAsync(m => m.ID == id);
            _context.Sebzeler.Remove(sebze);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SebzeExists(int id)
        {
            return _context.Sebzeler.Any(e => e.ID == id);
        }
    }
}
