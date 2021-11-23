using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_019_A.Models;

namespace UCP1_PAW_019_A.Controllers
{
    public class PenyewasController : Controller
    {
        private readonly RentPSContext _context;

        public PenyewasController(RentPSContext context)
        {
            _context = context;
        }

        // GET: Penyewas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penyewas.ToListAsync());
        }

        // GET: Penyewas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyewa = await _context.Penyewas
                .FirstOrDefaultAsync(m => m.IdPenyewa == id);
            if (penyewa == null)
            {
                return NotFound();
            }

            return View(penyewa);
        }

        // GET: Penyewas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Penyewas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPenyewa,Nama,NomorTelpon,Alamat")] Penyewa penyewa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penyewa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penyewa);
        }

        // GET: Penyewas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyewa = await _context.Penyewas.FindAsync(id);
            if (penyewa == null)
            {
                return NotFound();
            }
            return View(penyewa);
        }

        // POST: Penyewas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPenyewa,Nama,NomorTelpon,Alamat")] Penyewa penyewa)
        {
            if (id != penyewa.IdPenyewa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penyewa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenyewaExists(penyewa.IdPenyewa))
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
            return View(penyewa);
        }

        // GET: Penyewas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyewa = await _context.Penyewas
                .FirstOrDefaultAsync(m => m.IdPenyewa == id);
            if (penyewa == null)
            {
                return NotFound();
            }

            return View(penyewa);
        }

        // POST: Penyewas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penyewa = await _context.Penyewas.FindAsync(id);
            _context.Penyewas.Remove(penyewa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenyewaExists(int id)
        {
            return _context.Penyewas.Any(e => e.IdPenyewa == id);
        }
    }
}
