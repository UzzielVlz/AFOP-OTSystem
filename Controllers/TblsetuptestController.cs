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
    public class TblsetuptestController : Controller
    {
        private readonly Afop2023Context _context;

        public TblsetuptestController(Afop2023Context context)
        {
            _context = context;
        }

        // GET: Tblsetuptest
        public async Task<IActionResult> Index(string buscar)
        {
            var bScrips = from Tblsetuptest in _context.Tblsetuptests select Tblsetuptest;

            if (!String.IsNullOrEmpty(buscar))
            {
                bScrips = bScrips.Where(s => s.Name!.Contains(buscar));
            }

            return View(await bScrips.ToListAsync());
        }

        // GET: Tblsetuptest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblsetuptests == null)
            {
                return NotFound();
            }

            var tblsetuptest = await _context.Tblsetuptests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetuptest == null)
            {
                return NotFound();
            }

            return View(tblsetuptest);
        }

        // GET: Tblsetuptest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblsetuptest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Sources,J1channels,J2channels,Duttype,Dutfibers,SetupSpecIds,TestSteps,BiDirectional,Pdlmode,Opmdevices,IsActive")] Tblsetuptest tblsetuptest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblsetuptest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblsetuptest);
        }

        // GET: Tblsetuptest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblsetuptests == null)
            {
                return NotFound();
            }

            var tblsetuptest = await _context.Tblsetuptests.FindAsync(id);
            if (tblsetuptest == null)
            {
                return NotFound();
            }
            return View(tblsetuptest);
        }

        // POST: Tblsetuptest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Sources,J1channels,J2channels,Duttype,Dutfibers,SetupSpecIds,TestSteps,BiDirectional,Pdlmode,Opmdevices,IsActive")] Tblsetuptest tblsetuptest)
        {
            if (id != tblsetuptest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblsetuptest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblsetuptestExists(tblsetuptest.Id))
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
            return View(tblsetuptest);
        }

        // GET: Tblsetuptest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblsetuptests == null)
            {
                return NotFound();
            }

            var tblsetuptest = await _context.Tblsetuptests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetuptest == null)
            {
                return NotFound();
            }

            return View(tblsetuptest);
        }

        // POST: Tblsetuptest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblsetuptests == null)
            {
                return Problem("Entity set 'Afop2023Context.Tblsetuptests'  is null.");
            }
            var tblsetuptest = await _context.Tblsetuptests.FindAsync(id);
            if (tblsetuptest != null)
            {
                _context.Tblsetuptests.Remove(tblsetuptest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblsetuptestExists(int id)
        {
          return (_context.Tblsetuptests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
