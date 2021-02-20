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
    public class EventTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventTypes
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["EvnTypId"] = String.IsNullOrEmpty(sortOrder) ? "evn_typ_id" : "";
            ViewData["EvnTyp"] = String.IsNullOrEmpty(sortOrder) ? "evn_typ" : "";

            var eventtype = from s in _context.EventTypes
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
                eventtype = eventtype.Where(s => s.Id.ToString().Contains(searchString)
                                       || s.Type.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "evn_typ_id":
                    eventtype = eventtype.OrderByDescending(s => s.Id);
                    break;
                case "evn_typ":
                    eventtype = eventtype.OrderByDescending(s => s.Type);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<EventTypes>.CreateAsync(eventtype.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: EventTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTypes = await _context.EventTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventTypes == null)
            {
                return NotFound();
            }

            return View(eventTypes);
        }

        // GET: EventTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] EventTypes eventTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventTypes);
        }

        // GET: EventTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTypes = await _context.EventTypes.FindAsync(id);
            if (eventTypes == null)
            {
                return NotFound();
            }
            return View(eventTypes);
        }

        // POST: EventTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] EventTypes eventTypes)
        {
            if (id != eventTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTypesExists(eventTypes.Id))
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
            return View(eventTypes);
        }

        // GET: EventTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTypes = await _context.EventTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventTypes == null)
            {
                return NotFound();
            }

            return View(eventTypes);
        }

        // POST: EventTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventTypes = await _context.EventTypes.FindAsync(id);
            _context.EventTypes.Remove(eventTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTypesExists(int id)
        {
            return _context.EventTypes.Any(e => e.Id == id);
        }
    }
}
