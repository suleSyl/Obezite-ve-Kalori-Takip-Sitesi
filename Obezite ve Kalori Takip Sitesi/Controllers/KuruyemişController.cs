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
    public class KuruyemişController : Controller
    {
        private readonly FoodContext _context;

        public KuruyemişController(FoodContext context)
        {
            _context = context;
        }

        // GET: Kuruyemiş
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kuruyemişler.ToListAsync());
        }

        // GET: Kuruyemiş/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuruyemiş = await _context.Kuruyemişler
                .SingleOrDefaultAsync(m => m.ID == id);
            if (kuruyemiş == null)
            {
                return NotFound();
            }

            return View(kuruyemiş);
        }

        // GET: Kuruyemiş/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kuruyemiş/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] Kuruyemiş kuruyemiş)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kuruyemiş);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kuruyemiş);
        }

        // GET: Kuruyemiş/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuruyemiş = await _context.Kuruyemişler.SingleOrDefaultAsync(m => m.ID == id);
            if (kuruyemiş == null)
            {
                return NotFound();
            }
            return View(kuruyemiş);
        }

        // POST: Kuruyemiş/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] Kuruyemiş kuruyemiş)
        {
            if (id != kuruyemiş.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kuruyemiş);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KuruyemişExists(kuruyemiş.ID))
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
            return View(kuruyemiş);
        }

        // GET: Kuruyemiş/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuruyemiş = await _context.Kuruyemişler
                .SingleOrDefaultAsync(m => m.ID == id);
            if (kuruyemiş == null)
            {
                return NotFound();
            }

            return View(kuruyemiş);
        }

        // POST: Kuruyemiş/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kuruyemiş = await _context.Kuruyemişler.SingleOrDefaultAsync(m => m.ID == id);
            _context.Kuruyemişler.Remove(kuruyemiş);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KuruyemişExists(int id)
        {
            return _context.Kuruyemişler.Any(e => e.ID == id);
        }
    }
}
