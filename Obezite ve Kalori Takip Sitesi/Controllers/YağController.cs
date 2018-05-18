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
    public class YağController : Controller
    {
        private readonly FoodContext _context;

        public YağController(FoodContext context)
        {
            _context = context;
        }

        // GET: Yağ
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yağlar.ToListAsync());
        }

        // GET: Yağ/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yağ = await _context.Yağlar
                .SingleOrDefaultAsync(m => m.ID == id);
            if (yağ == null)
            {
                return NotFound();
            }

            return View(yağ);
        }

        // GET: Yağ/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yağ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Yiyecek,Kalori")] Yağ yağ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yağ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yağ);
        }

        // GET: Yağ/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yağ = await _context.Yağlar.SingleOrDefaultAsync(m => m.ID == id);
            if (yağ == null)
            {
                return NotFound();
            }
            return View(yağ);
        }

        // POST: Yağ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Yiyecek,Kalori")] Yağ yağ)
        {
            if (id != yağ.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yağ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YağExists(yağ.ID))
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
            return View(yağ);
        }

        // GET: Yağ/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yağ = await _context.Yağlar
                .SingleOrDefaultAsync(m => m.ID == id);
            if (yağ == null)
            {
                return NotFound();
            }

            return View(yağ);
        }

        // POST: Yağ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yağ = await _context.Yağlar.SingleOrDefaultAsync(m => m.ID == id);
            _context.Yağlar.Remove(yağ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YağExists(int id)
        {
            return _context.Yağlar.Any(e => e.ID == id);
        }
    }
}
