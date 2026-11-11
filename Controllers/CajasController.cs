using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FerreteriaValdiviaNueva.Data;
using FerreteriaValdiviaNueva.Models;

namespace FerreteriaValdiviaNueva.Controllers
{
    public class CajasController : Controller
    {
        private readonly AplicationDbContext _context;

        public CajasController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cajas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cajas.ToListAsync());
        }

        // GET: Cajas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cajas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCaja,FechaApertura,FechaCierre,MontoInicial,MontoFinal,Estado")] Caja caja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caja);
        }

        // GET: Cajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var caja = await _context.Cajas.FindAsync(id);
            if (caja == null) return NotFound();

            return View(caja);
        }

        // POST: Cajas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCaja,FechaApertura,FechaCierre,MontoInicial,MontoFinal,Estado")] Caja caja)
        {
            if (id != caja.IdCaja) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CajaExists(caja.IdCaja)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(caja);
        }

        // GET: Cajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var caja = await _context.Cajas.FirstOrDefaultAsync(m => m.IdCaja == id);
            if (caja == null) return NotFound();

            return View(caja);
        }

        // POST: Cajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caja = await _context.Cajas.FindAsync(id);
            if (caja != null)
            {
                _context.Cajas.Remove(caja);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CajaExists(int id)
        {
            return _context.Cajas.Any(e => e.IdCaja == id);
        }
    }
}