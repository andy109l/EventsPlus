using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsPlus.Data;
using EventsPlus.Models;
using EventsPlus.ViewModels;

namespace EventsPlus.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index_Deafult()
        {
            var applicationDbContext = _context.Event.Include(r => r.EventType).Include(p => p.Organizer).Include(g => g.VenueAddress);
            return View(await applicationDbContext.ToListAsync());

        }        // GET: Events 
        public ViewResult Index(int? id)
        {

            var viewModel = new EventAttendees();
            viewModel.Events = _context.Event
                .Include(r => r.EventType)
                .Include(p => p.Organizer)
                .Include(g => g.VenueAddress)
                .Include(p => p.GuestAttendees)
                .OrderBy(p => p.EventType);

            if (id != null)
            {
                ViewBag.Id = id.Value;
                viewModel.GuestAttendees = viewModel.Events.Where(f => f.Id == id.Value).Single().GuestAttendees;
            }

            return View(viewModel);

        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(r => r.EventType)
                .Include(p => p.Organizer)
                .Include(g => g.VenueAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Type");
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerContactNumber");
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "City");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrganizerId,EventsStartTime,EventsStartEnd,NumberOfAttendies,PrivacySetting,VerifiedOnly,EventTypeId,VenueAddressId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Type", @event.EventTypeId);
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerContactNumber", @event.OrganizerId);
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "City", @event.VenueAddressId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Type", @event.EventTypeId);
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerContactNumber", @event.OrganizerId);
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "City", @event.VenueAddressId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrganizerId,EventsStartTime,EventsStartEnd,NumberOfAttendies,PrivacySetting,VerifiedOnly,EventTypeId,VenueAddressId")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Type", @event.EventTypeId);
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerContactNumber", @event.OrganizerId);
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "City", @event.VenueAddressId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(r => r.EventType)
                .Include(p => p.Organizer)
                .Include(g => g.VenueAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
