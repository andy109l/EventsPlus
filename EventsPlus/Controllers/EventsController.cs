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
        public async Task<IActionResult> Index_Original()
        {
            var applicationDbContext = _context.Event.Include(r => r.EventType).Include(p => p.Organizer).Include(g => g.VenueAddress);
            return View(await applicationDbContext.ToListAsync());

        }        // GET: Events
        public async Task<IActionResult> IndexDeafault(string sortOrder, string searchString)
        {
            ViewData["TypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "event_type" : "";
            ViewData["DateStartSortParm"] = sortOrder == "SDate" ? "sdate_desc" : "SDate";
            ViewData["DateEndSortParm"] = sortOrder == "EDate" ? "edate_desc" : "EDate";
            ViewData["CurrentFilter"] = searchString;
            var Events = from s in _context.Event.Include(r => r.EventType).Include(p => p.Organizer).Include(g => g.VenueAddress)
                           select s;

            switch (sortOrder)
            {
                case "event_type":
                    Events = Events.OrderByDescending(s => s.EventType.Type);
                    break;
                case "SDate":
                    Events = Events.OrderBy(s => s.EventsStartTime);
                    break;            
                case "sdate_desc":
                    Events = Events.OrderByDescending(s => s.EventsStartTime);
                    break;
                case "EDate":
                    Events = Events.OrderBy(s => s.EventsStartEnd);
                    break;
                case "edate_desc":
                    Events = Events.OrderByDescending(s => s.EventsStartEnd);
                    break;               
                default:
                    Events = Events.OrderBy(s => s.Organizer.OrganizerContactNumber);
                    break;

            }
            return View(await Events.AsNoTracking().ToListAsync());
        }
        // GET: Events 
        public ViewResult Index(int? id, string sortOrder, string searchString, int? pageNumber)
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
            var Events = from s in _context.Event.Include(r => r.EventType).Include(p => p.Organizer).Include(g => g.VenueAddress)
                         select s;

            ViewData["CurrentSort"] = sortOrder;
            ViewData["TypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "event_type" : "";
            ViewData["DateStartSortParm"] = sortOrder == "SDate" ? "sdate_desc" : "SDate";
            ViewData["NumOfAttendees"] = String.IsNullOrEmpty(sortOrder) ? "att_num" : "";
            ViewData["PrivSet"] = String.IsNullOrEmpty(sortOrder) ? "priv_set" : "";
            ViewData["Organizer"] = String.IsNullOrEmpty(sortOrder) ? "organizer" : "";
            ViewData["EvId"] = String.IsNullOrEmpty(sortOrder) ? "ev_id" : "";
            ViewData["VerfOnl"] = String.IsNullOrEmpty(sortOrder) ? "ver_onl" : "";
            ViewData["VenAdd"] = String.IsNullOrEmpty(sortOrder) ? "ven_add" : "";
            ViewData["DateEndSortParm"] = sortOrder == "EDate" ? "edate_desc" : "EDate";
            ViewData["CurrentFilter"] = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.Events = viewModel.Events.Where(s => s.EventType.Type.Contains(searchString)
                || s.Organizer.OrganizerLastName.Contains(searchString)
                || s.Id.ToString().Contains(searchString)
                || s.VenueAddress.ContactAddressLine1.Contains(searchString)
                || s.NumberOfAttendies.ToString().Contains(searchString)
                || s.EventsStartTime.ToString().Contains(searchString)
                || s.EventsStartEnd.ToString().Contains(searchString));

            }
            switch (sortOrder)
            {
                case "event_type":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.EventType.Type);
                    break;
                case "organizer":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.Organizer.OrganizerLastName);
                    break;
                case "ev_id":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.Id);
                    break;
                case "att_num":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.NumberOfAttendies);
                    break;
                case "priv_set":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.PrivacySetting);
                    break;
                case "ver_onl":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.VerifiedOnly);
                    break;
                case "ven_add":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.VenueAddress.ContactAddressLine1);
                    break;
                case "SDate":
                    viewModel.Events = viewModel.Events.OrderBy(s => s.EventsStartTime);
                    break;
                case "sdate_desc":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.EventsStartTime);
                    break;
                case "EDate":
                    viewModel.Events = viewModel.Events.OrderBy(s => s.EventsStartEnd);
                    break;
                case "edate_desc":
                    viewModel.Events = viewModel.Events.OrderByDescending(s => s.EventsStartEnd);
                    break;
                default:
                    viewModel.Events = viewModel.Events.OrderBy(s => s.Organizer.OrganizerLastName);
                    break;

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
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerLastName");
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "ContactAddressLine1");
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
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerLastName", @event.OrganizerId);
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "ContactAddressLine1", @event.VenueAddressId);
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
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerLastName", @event.OrganizerId);
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "ContactAddressLine1", @event.VenueAddressId);
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
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "OrganizerLastName", @event.OrganizerId);
            ViewData["VenueAddressId"] = new SelectList(_context.VenueAddress, "Id", "ContactAddressLine1", @event.VenueAddressId);
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
