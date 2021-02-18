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
    public class GuestAttendeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestAttendeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GuestAttendees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GuestAttendee.Include(g => g.Event);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GuestAttendees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestAttendee = await _context.GuestAttendee
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestAttendee == null)
            {
                return NotFound();
            }

            return View(guestAttendee);
        }

        // GET: GuestAttendees/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id");
            return View();
        }

        // POST: GuestAttendees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,ContactNumber,EmailAddress,EventId")] GuestAttendee guestAttendee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestAttendee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id", guestAttendee.EventId);
            return View(guestAttendee);
        }

        // GET: GuestAttendees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestAttendee = await _context.GuestAttendee.FindAsync(id);
            if (guestAttendee == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id", guestAttendee.EventId);
            return View(guestAttendee);
        }

        // POST: GuestAttendees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,ContactNumber,EmailAddress,EventId")] GuestAttendee guestAttendee)
        {
            if (id != guestAttendee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestAttendee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestAttendeeExists(guestAttendee.Id))
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
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id", guestAttendee.EventId);
            return View(guestAttendee);
        }

        // GET: GuestAttendees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestAttendee = await _context.GuestAttendee
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestAttendee == null)
            {
                return NotFound();
            }

            return View(guestAttendee);
        }

        // POST: GuestAttendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestAttendee = await _context.GuestAttendee.FindAsync(id);
            _context.GuestAttendee.Remove(guestAttendee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestAttendeeExists(int id)
        {
            return _context.GuestAttendee.Any(e => e.Id == id);
        }
    }
}
