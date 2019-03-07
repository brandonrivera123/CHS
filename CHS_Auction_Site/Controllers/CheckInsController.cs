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
    public class CheckInsController : Controller
    {
        private readonly EventBasedAuctionSoftwareContext _context;

        public CheckInsController(EventBasedAuctionSoftwareContext context)
        {
            _context = context;
        }

        // GET: CheckIns
        public async Task<IActionResult> Index()
        {
            var checkins = await _context.CheckIns.Include(c => c.Event).Include(c => c.Guest).ToListAsync(); ;

            var EditCheckInVM = new EditCheckInVM
            {
                CheckIns = checkins
            };

            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", EditCheckInVM.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", EditCheckInVM.GuestId);

            return View(EditCheckInVM);
        }

        // GET: CheckIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIns = await _context.CheckIns
                .Include(c => c.Event)
                .Include(c => c.Guest)
                .FirstOrDefaultAsync(m => m.CheckInId == id);
            if (checkIns == null)
            {
                return NotFound();
            }

            return View(checkIns);
        }

        // GET: CheckIns/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName");
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName");
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckInId,CheckInBidderNumber,GuestId,EventId")] CheckIns checkIns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIns);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", checkIns.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", checkIns.GuestId);
            return View(checkIns);
        }

        // GET: CheckIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIns = await _context.CheckIns.FindAsync(id);
            if (checkIns == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", checkIns.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", checkIns.GuestId);
            return View(checkIns);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckInId,CheckInBidderNumber,GuestId,EventId")] CheckIns checkIns)
        {
            if (id != checkIns.CheckInId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkIns);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckInsExists(checkIns.CheckInId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", checkIns.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", checkIns.GuestId);
            return View(checkIns);
        }

        // GET: CheckIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIns = await _context.CheckIns
                .Include(c => c.Event)
                .Include(c => c.Guest)
                .FirstOrDefaultAsync(m => m.CheckInId == id);
            if (checkIns == null)
            {
                return NotFound();
            }

            return View(checkIns);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkIns = await _context.CheckIns.FindAsync(id);
            _context.CheckIns.Remove(checkIns);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInsExists(int id)
        {
            return _context.CheckIns.Any(e => e.CheckInId == id);
        }
    }
}
