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
    public class TblsetupdutController : Controller
    {
        private readonly Afop2023Context _context;

        public TblsetupdutController(Afop2023Context context)
        {
            _context = context;
        }

        // GET: Tblsetupdut
        public async Task<IActionResult> Index(string buscar)
        {
            var bSetupDuts = from Tblsetupdut in _context.Tblsetupduts select Tblsetupdut;

            if (!String.IsNullOrEmpty(buscar))
            {
                bSetupDuts = bSetupDuts.Where(s => s.Name!.Contains(buscar));
            }

            return View(await bSetupDuts.ToListAsync());
        }

        // GET: Tblsetupdut/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblsetupduts == null)
            {
                return NotFound();
            }

            var tblsetupdut = await _context.Tblsetupduts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetupdut == null)
            {
                return NotFound();
            }

            return View(tblsetupdut);
        }

        // GET: Tblsetupdut/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblsetupdut/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,Name,Description,PartNumber,Type,Fibers,PortNames,IsActive")] Tblsetupdut tblsetupdut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblsetupdut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblsetupdut);
        }

        // GET: Tblsetupdut/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblsetupduts == null)
            {
                return NotFound();
            }

            var tblsetupdut = await _context.Tblsetupduts.FindAsync(id);
            if (tblsetupdut == null)
            {
                return NotFound();
            }
            return View(tblsetupdut);
        }

        // POST: Tblsetupdut/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,Name,Description,PartNumber,Type,Fibers,PortNames,IsActive")] Tblsetupdut tblsetupdut)
        {
            if (id != tblsetupdut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblsetupdut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblsetupdutExists(tblsetupdut.Id))
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
            return View(tblsetupdut);
        }

        // GET: Tblsetupdut/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblsetupduts == null)
            {
                return NotFound();
            }

            var tblsetupdut = await _context.Tblsetupduts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetupdut == null)
            {
                return NotFound();
            }

            return View(tblsetupdut);
        }

        // POST: Tblsetupdut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblsetupduts == null)
            {
                return Problem("Entity set 'Afop2023Context.Tblsetupduts'  is null.");
            }
            var tblsetupdut = await _context.Tblsetupduts.FindAsync(id);
            if (tblsetupdut != null)
            {
                _context.Tblsetupduts.Remove(tblsetupdut);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblsetupdutExists(int id)
        {
          return (_context.Tblsetupduts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
