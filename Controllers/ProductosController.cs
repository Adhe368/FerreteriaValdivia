using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FerreteriaValdiviaNueva.Data;
using FerreteriaValdiviaNueva.Models;

namespace FerreteriaValdiviaNueva.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AplicationDbContext _context;

        public ProductosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            // Validar si el usuario inició sesión
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var productos = _context.Productos.Include(p => p.Categoria).Include(p => p.Proveedor);
            return View(await productos.ToListAsync());
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["Id_Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "NombreCategoria");
            ViewData["Id_Proveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "NombreProveedor");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProducto,Nombre_Producto,PrecioVenta,StockMinimo,StockActual,CantidadVendida,id_Categoria,id_Proveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "NombreCategoria", producto.id_Categoria);
            ViewData["Id_Proveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "NombreProveedor", producto.id_Proveedor);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null) return NotFound();

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            ViewData["Id_Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "NombreCategoria", producto.id_Categoria);
            ViewData["Id_Proveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "NombreProveedor", producto.id_Proveedor);
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoProducto,Nombre_Producto,PrecioVenta,StockMinimo,StockActual,CantidadVendida,id_Categoria,id_Proveedor")] Producto producto)
        {
            if (id != producto.CodigoProducto) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.CodigoProducto)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "NombreCategoria", producto.id_Categoria);
            ViewData["Id_Proveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "NombreProveedor", producto.id_Proveedor);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null) return NotFound();

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);

            if (producto == null) return NotFound();

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(string id)
        {
            return _context.Productos.Any(e => e.CodigoProducto == id);
        }

        // GET: Productos/Estadisticas
        public async Task<IActionResult> Estadisticas()
        {
            // Verificamos si la sesión está activa (siguiendo la seguridad que implementamos)
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var productos = _context.Productos;

            // 1. Total de registros en la tabla (COUNT)
            ViewBag.TotalProductos = await productos.CountAsync();

            // 2. Promedio de precios de venta de los productos (AVG)
            ViewBag.PrecioPromedio = await productos.AnyAsync() ? await productos.AverageAsync(p => p.PrecioVenta) : 0;

            // 3. Stock total disponible en almacén (SUM)
            ViewBag.StockTotal = await productos.AnyAsync() ? await productos.SumAsync(p => p.StockActual) : 0;

            // 4. Producto más vendido (Combinando ordenamiento descendente)
            var productoMasVendido = await productos
                .OrderByDescending(p => p.CantidadVendida)
                .FirstOrDefaultAsync();
            
            ViewBag.MasVendidoNombre = productoMasVendido?.Nombre_Producto ?? "N/D";
            ViewBag.MasVendidoCantidad = productoMasVendido?.CantidadVendida ?? 0;

            // 5. Producto con mayor precio del catálogo
            var productoMasCaro = await productos
                .OrderByDescending(p => p.PrecioVenta)
                .FirstOrDefaultAsync();

            ViewBag.MasCaroNombre = productoMasCaro?.Nombre_Producto ?? "N/D";
            ViewBag.MasCaroPrecio = productoMasCaro?.PrecioVenta ?? 0;

            return View();
        }
    }
}