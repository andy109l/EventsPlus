using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsPlus.Data;
using EventsPlus.Models;

namespace EventsPlus.Controllers
{
    public class VenueAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenueAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VenueAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.VenueAddress.ToListAsync());
        }

        // GET: VenueAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venueAddress = await _context.VenueAddress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venueAddress == null)
            {
                return NotFound();
            }

            return View(venueAddress);
        }

        // GET: VenueAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VenueAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactAddressLine1,ContactAddressLine2,ContactAddressLine3,ContactAddressLine4,Postcode,City,Country")] VenueAddress venueAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venueAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venueAddress);
        }

        // GET: VenueAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venueAddress = await _context.VenueAddress.FindAsync(id);
            if (venueAddress == null)
            {
                return NotFound();
            }
            return View(venueAddress);
        }

        // POST: VenueAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactAddressLine1,ContactAddressLine2,ContactAddressLine3,ContactAddressLine4,Postcode,City,Country")] VenueAddress venueAddress)
        {
            if (id != venueAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venueAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueAddressExists(venueAddress.Id))
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
            return View(venueAddress);
        }

        // GET: VenueAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venueAddress = await _context.VenueAddress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venueAddress == null)
            {
                return NotFound();
            }

            return View(venueAddress);
        }

        // POST: VenueAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venueAddress = await _context.VenueAddress.FindAsync(id);
            _context.VenueAddress.Remove(venueAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenueAddressExists(int id)
        {
            return _context.VenueAddress.Any(e => e.Id == id);
        }
    }
}
