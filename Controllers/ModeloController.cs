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
    public class ModeloController : Controller
    {
        private readonly ProductoContext _context;

        public ModeloController(ProductoContext context)
        {
            _context = context;
        }

        // GET: Modelo
        public async Task<IActionResult> Index()
        {
              return _context.Modelo != null ? 
                          View(await _context.Modelo.ToListAsync()) :
                          Problem("Entity set 'ProductoContext.Modelo'  is null.");
        }

        // GET: Modelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,MarcaId")] Modelo modelo)
        {   ModelState.Remove("Marca");
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Modelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        // POST: Modelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,MarcaId")] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Id))
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
            return View(modelo);
        }

        // GET: Modelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Modelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modelo == null)
            {
                return Problem("Entity set 'ProductoContext.Modelo'  is null.");
            }
            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo != null)
            {
                _context.Modelo.Remove(modelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
          return (_context.Modelo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
