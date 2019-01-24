using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHS_Auction_Site.Models;

namespace CHS_Auction_Site.Controllers
{
    public class GuestsController : Controller
    {
        private readonly EventBasedAuctionSoftwareContext _context;

        public GuestsController(EventBasedAuctionSoftwareContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            var eventBasedAuctionSoftwareContext = _context.Guests.Include(g => g.Organization);
            return View(await eventBasedAuctionSoftwareContext.ToListAsync());
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guests
                .Include(g => g.Organization)
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guests == null)
            {
                return NotFound();
            }

            return View(guests);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationName");
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestId,GuestFirstName,GuestLastName,GuestEmail,GuestPhone,OrganizationId,GuestAddress,GuestCity,GuestState,GuestZip")] Guests guests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationName", guests.OrganizationId);
            return View(guests);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guests.FindAsync(id);
            if (guests == null)
            {
                return NotFound();
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationName", guests.OrganizationId);
            return View(guests);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestId,GuestFirstName,GuestLastName,GuestEmail,GuestPhone,OrganizationId,GuestAddress,GuestCity,GuestState,GuestZip")] Guests guests)
        {
            if (id != guests.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestsExists(guests.GuestId))
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
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationName", guests.OrganizationId);
            return View(guests);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guests
                .Include(g => g.Organization)
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guests == null)
            {
                return NotFound();
            }

            return View(guests);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guests = await _context.Guests.FindAsync(id);
            _context.Guests.Remove(guests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestsExists(int id)
        {
            return _context.Guests.Any(e => e.GuestId == id);
        }
    }
}
