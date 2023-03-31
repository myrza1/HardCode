using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardCode.Data;
using HardCode.Models;

namespace HardCode.Controllers
{
    public class TayarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TayarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tayars
        public async Task<IActionResult> Index()
        {
              return _context.Tayar != null ? 
                          View(await _context.Tayar.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Tayar'  is null.");
        }

        // GET: Tayars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tayar == null)
            {
                return NotFound();
            }

            var tayar = await _context.Tayar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tayar == null)
            {
                return NotFound();
            }

            return View(tayar);
        }

        // GET: Tayars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tayars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Price")] Tayar tayar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tayar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tayar);
        }

        // GET: Tayars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tayar == null)
            {
                return NotFound();
            }

            var tayar = await _context.Tayar.FindAsync(id);
            if (tayar == null)
            {
                return NotFound();
            }
            return View(tayar);
        }

        // POST: Tayars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Price")] Tayar tayar)
        {
            if (id != tayar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tayar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TayarExists(tayar.Id))
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
            return View(tayar);
        }

        // GET: Tayars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tayar == null)
            {
                return NotFound();
            }

            var tayar = await _context.Tayar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tayar == null)
            {
                return NotFound();
            }

            return View(tayar);
        }

        // POST: Tayars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tayar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tayar'  is null.");
            }
            var tayar = await _context.Tayar.FindAsync(id);
            if (tayar != null)
            {
                _context.Tayar.Remove(tayar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TayarExists(int id)
        {
          return (_context.Tayar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
