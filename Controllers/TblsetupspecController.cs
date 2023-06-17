using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AFOP_OPTICAL_TESTINGv5.Models;

namespace AFOP_OPTICAL_TESTINGv5.Controllers
{
    public class TblsetupspecController : Controller
    {
        private readonly Afop2023Context _context;

        public TblsetupspecController(Afop2023Context context)
        {
            _context = context;
        }

        // GET: Tblsetupspec
        public async Task<IActionResult> Index(string buscar)
        {
            var bspec = from Tblsetupspec in _context.Tblsetupspecs select Tblsetupspec;

            if (!String.IsNullOrEmpty(buscar))
            {
                bspec = bspec.Where(s => s.Name!.Contains(buscar));
            }

            return View(await bspec.ToListAsync());
        }

        // GET: Tblsetupspec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblsetupspecs == null)
            {
                return NotFound();
            }

            var tblsetupspec = await _context.Tblsetupspecs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetupspec == null)
            {
                return NotFound();
            }

            return View(tblsetupspec);
        }

        // GET: Tblsetupspec/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblsetupspec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,MinSpec,MaxSpec,Setup,TableHeader,IsActive")] Tblsetupspec tblsetupspec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblsetupspec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblsetupspec);
        }

        // GET: Tblsetupspec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblsetupspecs == null)
            {
                return NotFound();
            }

            var tblsetupspec = await _context.Tblsetupspecs.FindAsync(id);
            if (tblsetupspec == null)
            {
                return NotFound();
            }
            return View(tblsetupspec);
        }

        // POST: Tblsetupspec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,MinSpec,MaxSpec,Setup,TableHeader,IsActive")] Tblsetupspec tblsetupspec)
        {
            if (id != tblsetupspec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblsetupspec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblsetupspecExists(tblsetupspec.Id))
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
            return View(tblsetupspec);
        }

        // GET: Tblsetupspec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblsetupspecs == null)
            {
                return NotFound();
            }

            var tblsetupspec = await _context.Tblsetupspecs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetupspec == null)
            {
                return NotFound();
            }

            return View(tblsetupspec);
        }

        // POST: Tblsetupspec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblsetupspecs == null)
            {
                return Problem("Entity set 'Afop2023Context.Tblsetupspecs'  is null.");
            }
            var tblsetupspec = await _context.Tblsetupspecs.FindAsync(id);
            if (tblsetupspec != null)
            {
                _context.Tblsetupspecs.Remove(tblsetupspec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblsetupspecExists(int id)
        {
          return (_context.Tblsetupspecs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
