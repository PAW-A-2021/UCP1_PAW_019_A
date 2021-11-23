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
    public class TransaksisController : Controller
    {
        private readonly RentPSContext _context;

        public TransaksisController(RentPSContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var rentPSContext = _context.Transaksis.Include(t => t.IdPenyewaNavigation).Include(t => t.IdPlayStationNavigation).Include(t => t.IdRentalNavigation);
            return View(await rentPSContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdPenyewaNavigation)
                .Include(t => t.IdPlayStationNavigation)
                .Include(t => t.IdRentalNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["IdPenyewa"] = new SelectList(_context.Penyewas, "IdPenyewa", "IdPenyewa");
            ViewData["IdPlayStation"] = new SelectList(_context.PlayStations, "IdPlayStation", "IdPlayStation");
            ViewData["IdRental"] = new SelectList(_context.Rentals, "IdRental", "IdRental");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,IdPenyewa,IdRental,IdPlayStation,HargaSewa")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPenyewa"] = new SelectList(_context.Penyewas, "IdPenyewa", "IdPenyewa", transaksi.IdPenyewa);
            ViewData["IdPlayStation"] = new SelectList(_context.PlayStations, "IdPlayStation", "IdPlayStation", transaksi.IdPlayStation);
            ViewData["IdRental"] = new SelectList(_context.Rentals, "IdRental", "IdRental", transaksi.IdRental);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["IdPenyewa"] = new SelectList(_context.Penyewas, "IdPenyewa", "IdPenyewa", transaksi.IdPenyewa);
            ViewData["IdPlayStation"] = new SelectList(_context.PlayStations, "IdPlayStation", "IdPlayStation", transaksi.IdPlayStation);
            ViewData["IdRental"] = new SelectList(_context.Rentals, "IdRental", "IdRental", transaksi.IdRental);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,IdPenyewa,IdRental,IdPlayStation,HargaSewa")] Transaksi transaksi)
        {
            if (id != transaksi.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.IdTransaksi))
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
            ViewData["IdPenyewa"] = new SelectList(_context.Penyewas, "IdPenyewa", "IdPenyewa", transaksi.IdPenyewa);
            ViewData["IdPlayStation"] = new SelectList(_context.PlayStations, "IdPlayStation", "IdPlayStation", transaksi.IdPlayStation);
            ViewData["IdRental"] = new SelectList(_context.Rentals, "IdRental", "IdRental", transaksi.IdRental);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdPenyewaNavigation)
                .Include(t => t.IdPlayStationNavigation)
                .Include(t => t.IdRentalNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksis.FindAsync(id);
            _context.Transaksis.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksis.Any(e => e.IdTransaksi == id);
        }
    }
}
