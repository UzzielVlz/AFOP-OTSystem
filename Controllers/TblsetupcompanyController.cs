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
    public class TblsetupcompanyController : Controller
    {
        private readonly Afop2023Context _context;

        public TblsetupcompanyController(Afop2023Context context)
        {
            _context = context;
        }

        // GET: Tblsetupcompany
        public async Task<IActionResult> Index(string buscar)
        {
            var bCompany = from Tblsetupcompany in _context.Tblsetupcompanies select Tblsetupcompany;

            if (!String.IsNullOrEmpty(buscar))
            {
                bCompany = bCompany.Where(s => s.Name!.Contains(buscar));
            }

            return View(await bCompany.ToListAsync());
        }

        // GET: Tblsetupcompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblsetupcompanies == null)
            {
                return NotFound();
            }

            var tblsetupcompany = await _context.Tblsetupcompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetupcompany == null)
            {
                return NotFound();
            }

            return View(tblsetupcompany);
        }

        // GET: Tblsetupcompany/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblsetupcompany/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,CompanyName,Address,City,State,Country,ZipCode,Phone,IsActive")] Tblsetupcompany tblsetupcompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblsetupcompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblsetupcompany);
        }

        // GET: Tblsetupcompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblsetupcompanies == null)
            {
                return NotFound();
            }

            var tblsetupcompany = await _context.Tblsetupcompanies.FindAsync(id);
            if (tblsetupcompany == null)
            {
                return NotFound();
            }
            return View(tblsetupcompany);
        }

        // POST: Tblsetupcompany/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,CompanyName,Address,City,State,Country,ZipCode,Phone,IsActive")] Tblsetupcompany tblsetupcompany)
        {
            if (id != tblsetupcompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblsetupcompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblsetupcompanyExists(tblsetupcompany.Id))
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
            return View(tblsetupcompany);
        }

        // GET: Tblsetupcompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblsetupcompanies == null)
            {
                return NotFound();
            }

            var tblsetupcompany = await _context.Tblsetupcompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblsetupcompany == null)
            {
                return NotFound();
            }

            return View(tblsetupcompany);
        }

        // POST: Tblsetupcompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblsetupcompanies == null)
            {
                return Problem("Entity set 'Afop2023Context.Tblsetupcompanies'  is null.");
            }
            var tblsetupcompany = await _context.Tblsetupcompanies.FindAsync(id);
            if (tblsetupcompany != null)
            {
                _context.Tblsetupcompanies.Remove(tblsetupcompany);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblsetupcompanyExists(int id)
        {
          return (_context.Tblsetupcompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
