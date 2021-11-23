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
    public class PlayStationsController : Controller
    {
        private readonly RentPSContext _context;

        public PlayStationsController(RentPSContext context)
        {
            _context = context;
        }

        // GET: PlayStations
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayStations.ToListAsync());
        }

        // GET: PlayStations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playStation = await _context.PlayStations
                .FirstOrDefaultAsync(m => m.IdPlayStation == id);
            if (playStation == null)
            {
                return NotFound();
            }

            return View(playStation);
        }

        // GET: PlayStations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlayStation,JenisPlayStation")] PlayStation playStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playStation);
        }

        // GET: PlayStations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playStation = await _context.PlayStations.FindAsync(id);
            if (playStation == null)
            {
                return NotFound();
            }
            return View(playStation);
        }

        // POST: PlayStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlayStation,JenisPlayStation")] PlayStation playStation)
        {
            if (id != playStation.IdPlayStation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayStationExists(playStation.IdPlayStation))
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
            return View(playStation);
        }

        // GET: PlayStations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playStation = await _context.PlayStations
                .FirstOrDefaultAsync(m => m.IdPlayStation == id);
            if (playStation == null)
            {
                return NotFound();
            }

            return View(playStation);
        }

        // POST: PlayStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playStation = await _context.PlayStations.FindAsync(id);
            _context.PlayStations.Remove(playStation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayStationExists(int id)
        {
            return _context.PlayStations.Any(e => e.IdPlayStation == id);
        }
    }
}
