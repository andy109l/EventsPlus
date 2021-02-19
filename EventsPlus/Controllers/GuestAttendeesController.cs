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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["AttId"] = String.IsNullOrEmpty(sortOrder) ? "att_id" : "";
            ViewData["LNam"] = String.IsNullOrEmpty(sortOrder) ? "l_nam" : "";
            ViewData["F_Nam"] = String.IsNullOrEmpty(sortOrder) ? "f_nam" : "";
            ViewData["C_Num"] = String.IsNullOrEmpty(sortOrder) ? "c_num" : "";
            ViewData["E_Add"] = String.IsNullOrEmpty(sortOrder) ? "e_add" : "";
            ViewData["Ev_Id"] = String.IsNullOrEmpty(sortOrder) ? "ev_id" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;


            var guestattendee = from s in _context.GuestAttendee.Include(e => e.Event)
                                select s;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                guestattendee = guestattendee.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString)
                                       || s.ContactNumber.Contains(searchString)
                                       || s.EmailAddress.Contains(searchString)
                                       || s.Id.ToString().Contains(searchString)
                                       || s.Event.Id.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "att_id":
                    guestattendee = guestattendee.OrderByDescending(s => s.Id);
                    break;
                case "l_nam":
                    guestattendee = guestattendee.OrderByDescending(s => s.LastName);
                    break;
                case "f_nam":
                    guestattendee = guestattendee.OrderByDescending(s => s.FirstName);
                    break;
                case "c_num":
                    guestattendee = guestattendee.OrderByDescending(s => s.ContactNumber);
                    break;
                case "e_add":
                    guestattendee = guestattendee.OrderByDescending(s => s.EmailAddress);
                    break;
                case "ev_id":
                    guestattendee = guestattendee.OrderByDescending(s => s.Event.Id);
                    break;
            }


            int pageSize = 3;
            return View(await PaginatedList<GuestAttendee>.CreateAsync(guestattendee.AsNoTracking(), pageNumber ?? 1, pageSize));
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
