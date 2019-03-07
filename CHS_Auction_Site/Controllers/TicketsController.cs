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
    public class TicketsController : Controller
    {
        private readonly EventBasedAuctionSoftwareContext _context;

        public TicketsController(EventBasedAuctionSoftwareContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets.Include(t => t.Event).Include(t => t.Guest).Include(t => t.Transaction).ToListAsync();

            var EditTicketVM = new EditTicketVM
            {
                Tickets = tickets
            };

            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", EditTicketVM.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", EditTicketVM.GuestId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", EditTicketVM.TransactionId);

            return View(EditTicketVM);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .Include(t => t.Event)
                .Include(t => t.Guest)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName");
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName");
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,GuestId,EventId,TicketQuantity,TicketPrice,TicketTotalPrice,TransactionId")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", tickets.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", tickets.GuestId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", tickets.TransactionId);
            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", tickets.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", tickets.GuestId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", tickets.TransactionId);
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,GuestId,EventId,TicketQuantity,TicketPrice,TicketTotalPrice,TransactionId")] Tickets tickets)
        {
            if (id != tickets.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketsExists(tickets.TicketId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", tickets.EventId);
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestFirstName", tickets.GuestId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", tickets.TransactionId);
            return View(tickets);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .Include(t => t.Event)
                .Include(t => t.Guest)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.EventId == id);
        }
    }
}
