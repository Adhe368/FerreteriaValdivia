using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FerreteriaValdiviaNueva.Data;
using FerreteriaValdiviaNueva.Models;

namespace FerreteriaValdiviaNueva.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly AplicationDbContext _context;

        public EmpleadosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var empleados = _context.Empleados.Include(e => e.Rol);
            return View(await empleados.ToListAsync());
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "NombreRol");
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,Nombre,Apellido,Telefono,IdRol")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "NombreRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "NombreRol", empleado.IdRol);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Apellido,Telefono,IdRol")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "NombreRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados
                .Include(e => e.Rol)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null) return NotFound();

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }

        // GET: Empleados/Estadisticas
        public async Task<IActionResult> Estadisticas()
        {
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var empleados = _context.Empleados;

            // 1. Total de empleados registrados (COUNT)
            ViewBag.TotalEmpleados = await empleados.CountAsync();

            // 2. Primer empleado registrado ordenado por su ID
            var primerEmpleado = await empleados.OrderBy(e => e.IdEmpleado).FirstOrDefaultAsync();
            ViewBag.PrimerEmpleado = primerEmpleado != null ? $"{primerEmpleado.Nombre} {primerEmpleado.Apellido}" : "N/D";

            return View();
        }
    }
}