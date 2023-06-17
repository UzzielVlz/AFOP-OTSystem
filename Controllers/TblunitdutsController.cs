using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AFOP_OPTICAL_TESTINGv5.Models;
using System.Net;

namespace AFOP_OPTICAL_TESTINGv5.Controllers
{
    public class TblunitdutsController : Controller
    {
        private Afop2023Context db = new Afop2023Context();

        private readonly Afop2023Context _context;

        public TblunitdutsController(Afop2023Context context)
        {
            _context = context;
        }

        // GET: Tblunitduts
        public async Task<IActionResult> Index(string buscar)
        {
            var bUnitduts = from tblunitdut in _context.Tblunitduts select tblunitdut;

            if (!String.IsNullOrEmpty(buscar))
            {
                bUnitduts = bUnitduts.Where(s => s.SerialNumber!.Contains(buscar));
            }

            return View(await bUnitduts.ToListAsync());
        }

        // GET: Tblunitduts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblunitduts == null)
            {
                return NotFound();
            }
            var tblunitdut = await _context.Tblunitduts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblunitdut == null)
            {
                return NotFound();
            }

            return View(tblunitdut);
        }

        // GET: Tblunitduts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblunitduts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SetupDutid,SerialNumber")] Tblunitdut tblunitdut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblunitdut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblunitdut);
        }

        // GET: Tblunitduts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblunitduts == null)
            {
                return NotFound();               
            }
            //Tblunitdut tblunitdut = db.Tblunitduts.Find(id);
            var tblunitdut = await _context.Tblunitduts.FindAsync(id);
            if (tblunitdut == null)
            {
                return NotFound();
            }
            return View(tblunitdut);
        }

        // POST: Tblunitduts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SetupDutid,SerialNumber")] Tblunitdut tblunitdut)
        {
            if (id != tblunitdut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblunitdut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblunitdutExists(tblunitdut.Id))
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
            return View(tblunitdut);
        }

        // GET: Tblunitduts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblunitduts == null)
            {
                return NotFound();
            }

            var tblunitdut = await _context.Tblunitduts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblunitdut == null)
            {
                return NotFound();
            }

            return View(tblunitdut);
        }

        // POST: Tblunitduts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblunitduts == null)
            {
                return Problem("Entity set 'Afop2023Context.Tblunitduts'  is null.");
            }
            var tblunitdut = await _context.Tblunitduts.FindAsync(id);
            if (tblunitdut != null)
            {
                _context.Tblunitduts.Remove(tblunitdut);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblunitdutExists(int id)
        {
          return (_context.Tblunitduts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
