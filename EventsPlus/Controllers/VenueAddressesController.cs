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
        /// <summary>
        /// Gets and returns the view of the models gets the required data from the database for them
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            var venueaddress = from s in _context.VenueAddress
                                select s;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
        //Sorting filtering data and logic
            ViewData["VenIdParm"] = String.IsNullOrEmpty(sortOrder) ? "ven_id_parm" : "";
            ViewData["Con_Add_1Parm"] = String.IsNullOrEmpty(sortOrder) ? "con_add_1_parm" : "";
            ViewData["Con_Add_2Parm"] = String.IsNullOrEmpty(sortOrder) ? "con_add_2_parm" : "";
            ViewData["Con_Add_3Parm"] = String.IsNullOrEmpty(sortOrder) ? "con_add_3_parm" : "";
            ViewData["Con_Add_4Parm"] = String.IsNullOrEmpty(sortOrder) ? "con_add_4_parm" : "";
            ViewData["PostcodeParm"] = String.IsNullOrEmpty(sortOrder) ? "postcode_parm" : "";
            ViewData["CityParm"] = String.IsNullOrEmpty(sortOrder) ? "city_parm" : "";
            ViewData["CountParm"] = String.IsNullOrEmpty(sortOrder) ? "count_parm" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
        //Filtering loogic for the search box, filters the results
            if (!String.IsNullOrEmpty(searchString))
            {
                venueaddress = venueaddress.Where(s => s.Id.ToString().Contains(searchString)
                                       || s.ContactAddressLine1.Contains(searchString)
                                       || s.ContactAddressLine2.Contains(searchString)
                                       || s.ContactAddressLine3.Contains(searchString)
                                       || s.ContactAddressLine4.Contains(searchString)
                                       || s.Postcode.Contains(searchString)
                                       || s.City.Contains(searchString)
                                       || s.Country.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ven_id_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.Id);
                    break;
                case "con_add_1_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.ContactAddressLine1);
                    break;
                case "con_add_2_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.ContactAddressLine2);
                    break;
                case "con_add_3_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.ContactAddressLine3);
                    break;
                case "con_add_4_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.ContactAddressLine4);
                    break;
                case "postcode_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.Postcode);
                    break;
                case "city_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.City);
                    break;
                case "count_parm":
                    venueaddress = venueaddress.OrderByDescending(s => s.Country);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<VenueAddress>.CreateAsync(venueaddress.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: VenueAddresses/Details/5
        /// <summary>
        /// Gets the required data from the database for the chosen record and displays the Details view for the chosen record in the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Displays the Create view for the VenueAddresses
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: VenueAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Adds the newly created record to the database based in the bind property and the model, returns to the Inedx view
        /// </summary>
        /// <param name="venueAddress"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Displays Edit form of the chosen Id, if the Id is not found returns Id not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Edits the chosen record in the Event table based on the Id, if the Id is not found returns not found, redirects to the Index view
        /// </summary>
        /// <param name="id"></param>
        /// <param name="venueAddress"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Displays a delete dox for the chosen record in the table based on the Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Performs the delete action of the chosen record in the database and returns the Index View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
