using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using client.Data;
using client.Models;

namespace client.Controllers
{
    public class VersementController : Controller
    {
        private readonly BetaxeContext _context;

        public VersementController(BetaxeContext context)
        {
            _context = context;
        }

        // GET: Versement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Versement.ToListAsync());
        }

        // GET: Versement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versement = await _context.Versement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versement == null)
            {
                return NotFound();
            }

            return View(versement);
        }

        // GET: Versement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Versement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,ReleaseDate,UpdateDate,IsChecked")] Versement versement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(versement);
        }

        // GET: Versement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versement = await _context.Versement.FindAsync(id);
            if (versement == null)
            {
                return NotFound();
            }
            return View(versement);
        }

        // POST: Versement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,ReleaseDate,UpdateDate,IsChecked")] Versement versement)
        {
            if (id != versement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersementExists(versement.Id))
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
            return View(versement);
        }

        // GET: Versement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versement = await _context.Versement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versement == null)
            {
                return NotFound();
            }

            return View(versement);
        }

        // POST: Versement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var versement = await _context.Versement.FindAsync(id);
            if (versement != null)
            {
                _context.Versement.Remove(versement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersementExists(int id)
        {
            return _context.Versement.Any(e => e.Id == id);
        }
    }
}
