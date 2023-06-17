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
    public class DATAController : Controller
    {
        private readonly Afop2023Context _context;

        public DATAController(Afop2023Context context)
        {
            _context = context;
        }

        // GET: DATA
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tblacquisitions.ToListAsync());
        }

        // GET: DATA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblacquisitions == null)
            {
                return NotFound();
            }

            var tblacquisition = await _context.Tblacquisitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblacquisition == null)
            {
                return NotFound();
            }

            return View(tblacquisition);
        }

        // GET: DATA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DATA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnitTestId,UnitDutid,TestStep,Wavelength,Dutpath,DutinputPort,DutoutputPort,InputMtjid,OutputMtjid,RefPower,Dutpower,Results,DateTime")] Tblacquisition tblacquisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblacquisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblacquisition);
        }

        // GET: DATA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblacquisitions == null)
            {
                return NotFound();
            }

            var tblacquisition = await _context.Tblacquisitions.FindAsync(id);
            if (tblacquisition == null)
            {
                return NotFound();
            }
            return View(tblacquisition);
        }

        // POST: DATA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnitTestId,UnitDutid,TestStep,Wavelength,Dutpath,DutinputPort,DutoutputPort,InputMtjid,OutputMtjid,RefPower,Dutpower,Results,DateTime")] Tblacquisition tblacquisition)
        {
            if (id != tblacquisition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblacquisition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblacquisitionExists(tblacquisition.Id))
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
            return View(tblacquisition);
        }

        // GET: DATA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblacquisitions == null)
            {
                return NotFound();
            }

            var tblacquisition = await _context.Tblacquisitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblacquisition == null)
            {
                return NotFound();
            }

            return View(tblacquisition);
        }

        // POST: DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblacquisitions == null)
            {
                return Problem("Entity set 'Afop2023Context.Tblacquisitions'  is null.");
            }
            var tblacquisition = await _context.Tblacquisitions.FindAsync(id);
            if (tblacquisition != null)
            {
                _context.Tblacquisitions.Remove(tblacquisition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblacquisitionExists(int id)
        {
          return _context.Tblacquisitions.Any(e => e.Id == id);
        }
    }
}
