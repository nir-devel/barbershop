using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;


namespace BarberShop.Controllers
{
    [Authorize]
    public class HairCutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HairCutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HairCuts
        public async Task<IActionResult> Index()
        {
              return _context.HairCuts != null ? 
                          View(await _context.HairCuts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HairCuts'  is null.");
        }

        // GET: HairCuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HairCuts == null)
            {
                return NotFound();
            }

            var hairCut = await _context.HairCuts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairCut == null)
            {
                return NotFound();
            }

            return View(hairCut);
        }

        // GET: HairCuts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HairCuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Barber,Date")] HairCut hairCut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hairCut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hairCut);
        }

        // GET: HairCuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HairCuts == null)
            {
                return NotFound();
            }

            var hairCut = await _context.HairCuts.FindAsync(id);
            if (hairCut == null)
            {
                return NotFound();
            }
            return View(hairCut);
        }

        // POST: HairCuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Barber,Date")] HairCut hairCut)
        {
            if (id != hairCut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairCut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairCutExists(hairCut.Id))
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
            return View(hairCut);
        }

        // GET: HairCuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HairCuts == null)
            {
                return NotFound();
            }

            var hairCut = await _context.HairCuts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairCut == null)
            {
                return NotFound();
            }

            return View(hairCut);
        }

        // POST: HairCuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HairCuts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HairCuts'  is null.");
            }
            var hairCut = await _context.HairCuts.FindAsync(id);
            if (hairCut != null)
            {
                _context.HairCuts.Remove(hairCut);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairCutExists(int id)
        {
          return (_context.HairCuts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
