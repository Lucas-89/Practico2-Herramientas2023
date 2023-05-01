using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockElectronica.Data;
using StockElectronica.Models;

namespace StockElectronica.Controllers
{
    public class NumeroSerieController : Controller
    {
        private readonly ProductoContext _context;

        public NumeroSerieController(ProductoContext context)
        {
            _context = context;
        }

        // GET: NumeroSerie
        public async Task<IActionResult> Index()
        {
              return _context.NumeroSerie != null ? 
                          View(await _context.NumeroSerie.ToListAsync()) :
                          Problem("Entity set 'ProductoContext.NumeroSerie'  is null.");
        }

        // GET: NumeroSerie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NumeroSerie == null)
            {
                return NotFound();
            }

            var numeroSerie = await _context.NumeroSerie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numeroSerie == null)
            {
                return NotFound();
            }

            return View(numeroSerie);
        }

        // GET: NumeroSerie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumeroSerie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdId,ParNumer")] NumeroSerie numeroSerie)
        {   
            ModelState.Remove("producto");
            if (ModelState.IsValid)
            {
                _context.Add(numeroSerie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numeroSerie);
        }

        // GET: NumeroSerie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NumeroSerie == null)
            {
                return NotFound();
            }

            var numeroSerie = await _context.NumeroSerie.FindAsync(id);
            if (numeroSerie == null)
            {
                return NotFound();
            }
            return View(numeroSerie);
        }

        // POST: NumeroSerie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdId,ParNumer")] NumeroSerie numeroSerie)
        {
            if (id != numeroSerie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numeroSerie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumeroSerieExists(numeroSerie.Id))
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
            return View(numeroSerie);
        }

        // GET: NumeroSerie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NumeroSerie == null)
            {
                return NotFound();
            }

            var numeroSerie = await _context.NumeroSerie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numeroSerie == null)
            {
                return NotFound();
            }

            return View(numeroSerie);
        }

        // POST: NumeroSerie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NumeroSerie == null)
            {
                return Problem("Entity set 'ProductoContext.NumeroSerie'  is null.");
            }
            var numeroSerie = await _context.NumeroSerie.FindAsync(id);
            if (numeroSerie != null)
            {
                _context.NumeroSerie.Remove(numeroSerie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumeroSerieExists(int id)
        {
          return (_context.NumeroSerie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
