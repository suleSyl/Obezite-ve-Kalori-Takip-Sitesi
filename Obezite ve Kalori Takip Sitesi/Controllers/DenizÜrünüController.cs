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
    public class DenizÜrünüController : Controller
    {
        private readonly FoodContext _context;

        public DenizÜrünüController(FoodContext context)
        {
            _context = context;
        }

        // GET: DenizÜrünü
        public async Task<IActionResult> Index()
        {
            return View(await _context.DenizÜrünleri.ToListAsync());
        }

        // GET: DenizÜrünü/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denizÜrünü = await _context.DenizÜrünleri
                .SingleOrDefaultAsync(m => m.ID == id);
            if (denizÜrünü == null)
            {
                return NotFound();
            }

            return View(denizÜrünü);
        }

        // GET: DenizÜrünü/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DenizÜrünü/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] DenizÜrünü denizÜrünü)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denizÜrünü);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denizÜrünü);
        }

        // GET: DenizÜrünü/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denizÜrünü = await _context.DenizÜrünleri.SingleOrDefaultAsync(m => m.ID == id);
            if (denizÜrünü == null)
            {
                return NotFound();
            }
            return View(denizÜrünü);
        }

        // POST: DenizÜrünü/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] DenizÜrünü denizÜrünü)
        {
            if (id != denizÜrünü.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denizÜrünü);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenizÜrünüExists(denizÜrünü.ID))
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
            return View(denizÜrünü);
        }

        // GET: DenizÜrünü/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denizÜrünü = await _context.DenizÜrünleri
                .SingleOrDefaultAsync(m => m.ID == id);
            if (denizÜrünü == null)
            {
                return NotFound();
            }

            return View(denizÜrünü);
        }

        // POST: DenizÜrünü/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denizÜrünü = await _context.DenizÜrünleri.SingleOrDefaultAsync(m => m.ID == id);
            _context.DenizÜrünleri.Remove(denizÜrünü);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenizÜrünüExists(int id)
        {
            return _context.DenizÜrünleri.Any(e => e.ID == id);
        }
    }
}
