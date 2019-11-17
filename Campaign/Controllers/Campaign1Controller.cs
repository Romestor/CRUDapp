using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Campaign.Data;
using Campaign.Models;

namespace Campaign.Controllers
{
    public class Campaign1Controller : Controller
    {
        private readonly CampaignContext _context;

        public Campaign1Controller(CampaignContext context)
        {
            _context = context;
        }

        // GET: Campaign1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaigns.ToListAsync());
        }

        // GET: Campaign1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign1 = await _context.Campaigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign1 == null)
            {
                return NotFound();
            }

            return View(campaign1);
        }

        // GET: Campaign1/Create
        public IActionResult Create()
        {
            ViewBag.TownList = _context.Towns.Select(x => new SelectListItem { Text = x.Name, Value = x.Name });

            return View();
        }

        // POST: Campaign1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Keywords,Fund,Bid,Town,Status,Radius")] Campaign1 campaign1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaign1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaign1);
        }

        // GET: Campaign1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign1 = await _context.Campaigns.FindAsync(id);
            if (campaign1 == null)
            {
                return NotFound();
            }

            ViewBag.TownList = _context.Towns.Select(x => new SelectListItem { Text = x.Name, Value = x.Name });
            return View(campaign1);
        }

        // POST: Campaign1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Keywords,Fund,Bid,Town,Status,Radius")] Campaign1 campaign1)
        {
            if (id != campaign1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Campaign1Exists(campaign1.Id))
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
            return View(campaign1);
        }

        // GET: Campaign1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign1 = await _context.Campaigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign1 == null)
            {
                return NotFound();
            }

            return View(campaign1);
        }

        // POST: Campaign1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaign1 = await _context.Campaigns.FindAsync(id);
            _context.Campaigns.Remove(campaign1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Campaign1Exists(int id)
        {
            return _context.Campaigns.Any(e => e.Id == id);
        }
    }
}
