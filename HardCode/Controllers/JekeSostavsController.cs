using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardCode.Data;
using HardCode.Models;
using Microsoft.AspNetCore.Authorization;

namespace HardCode.Controllers
{
    [Authorize]
    public class JekeSostavsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JekeSostavsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JekeSostavs
        public async Task<IActionResult> Index()
        {
              return _context.JekeSostav != null ? 
                          View(await _context.JekeSostav.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.JekeSostav'  is null.");
        }

        // GET: JekeSostavs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JekeSostav == null)
            {
                return NotFound();
            }

            var jekeSostav = await _context.JekeSostav
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jekeSostav == null)
            {
                return NotFound();
            }

            return View(jekeSostav);
        }

        // GET: JekeSostavs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JekeSostavs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FIO,Doljnost,Education,Birthday,InviteMonthYear,Sinyptilik,Eskertpe")] JekeSostav jekeSostav)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jekeSostav);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jekeSostav);
        }

        // GET: JekeSostavs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JekeSostav == null)
            {
                return NotFound();
            }

            var jekeSostav = await _context.JekeSostav.FindAsync(id);
            if (jekeSostav == null)
            {
                return NotFound();
            }
            return View(jekeSostav);
        }

        // POST: JekeSostavs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FIO,Doljnost,Education,Birthday,InviteMonthYear,Sinyptilik,Eskertpe")] JekeSostav jekeSostav)
        {
            if (id != jekeSostav.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jekeSostav);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JekeSostavExists(jekeSostav.Id))
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
            return View(jekeSostav);
        }

        // GET: JekeSostavs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JekeSostav == null)
            {
                return NotFound();
            }

            var jekeSostav = await _context.JekeSostav
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jekeSostav == null)
            {
                return NotFound();
            }

            return View(jekeSostav);
        }

        // POST: JekeSostavs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JekeSostav == null)
            {
                return Problem("Entity set 'ApplicationDbContext.JekeSostav'  is null.");
            }
            var jekeSostav = await _context.JekeSostav.FindAsync(id);
            if (jekeSostav != null)
            {
                _context.JekeSostav.Remove(jekeSostav);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JekeSostavExists(int id)
        {
          return (_context.JekeSostav?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
