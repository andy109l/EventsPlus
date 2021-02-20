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
    public class OrganizersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizersController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Organizers
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["OrgId"] = String.IsNullOrEmpty(sortOrder) ? "org_id" : "";
            ViewData["OrgLNam"] = String.IsNullOrEmpty(sortOrder) ? "org_l_nam" : "";
            ViewData["Org_F_Nam"] = String.IsNullOrEmpty(sortOrder) ? "org_f_nam": "";  
            ViewData["Org_C_Num"] = String.IsNullOrEmpty(sortOrder) ? "org_c_num" : "";
            ViewData["Org_E_Add"] = String.IsNullOrEmpty(sortOrder) ? "org_e_add" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var organizer = from s in _context.Organizer
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
                organizer = organizer.Where(s => s.OrganizerLastName.Contains(searchString)
                                       || s.OrganizerFirstName.Contains(searchString)
                                       || s.OrganizerContactNumber.Contains(searchString)
                                       || s.OrganizerEmailAddress.Contains(searchString)
                                       || s.Id.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "org_id":
                    organizer = organizer.OrderByDescending(s => s.Id);
                    break;
                case "org_l_nam":
                    organizer = organizer.OrderByDescending(s => s.OrganizerLastName);
                    break;
                case "org_f_nam":
                    organizer = organizer.OrderByDescending(s => s.OrganizerFirstName);
                    break;
                case "org_c_num":
                    organizer = organizer.OrderByDescending(s => s.OrganizerContactNumber);
                    break;
                case "org_e_add":
                    organizer = organizer.OrderByDescending(s => s.OrganizerEmailAddress);
                    break;
           }


            int pageSize = 3;
            return View(await PaginatedList<Organizer>.CreateAsync(organizer.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


            

            // GET: Organizers/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // GET: Organizers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrganizerLastName,OrganizerFirstName,OrganizerContactNumber,OrganizerEmailAddress")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizer);
        }

        // GET: Organizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizer.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrganizerLastName,OrganizerFirstName,OrganizerContactNumber,OrganizerEmailAddress")] Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerExists(organizer.Id))
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
            return View(organizer);
        }

        // GET: Organizers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizer = await _context.Organizer.FindAsync(id);
            _context.Organizer.Remove(organizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerExists(int id)
        {
            return _context.Organizer.Any(e => e.Id == id);
        }
    }
}
