using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FerreteriaValdiviaNueva.Data;
using FerreteriaValdiviaNueva.Models;

namespace FerreteriaValdiviaNueva.Controllers
{
    public class AccountController : Controller
    {
        private readonly AplicationDbContext _context;

        public AccountController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            // Si ya hay una sesión activa, redirigir al inicio o productos
            if (HttpContext.Session.GetString("UsuarioNombre") != null)
            {
                return RedirectToAction("Index", "Productos");
            }
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string correo, string password)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Por favor, ingresa el correo y la contraseña.";
                return View();
            }

            // Buscar al empleado y su rol asociado
            var empleado = await _context.Empleados
                .Include(e => e.Rol)
                .FirstOrDefaultAsync(e => e.Correo == correo && e.Password == password);

            if (empleado == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }

            // Guardar datos clave en la Sesión de ASP.NET Core
            HttpContext.Session.SetInt32("UsuarioId", empleado.IdEmpleado);
            HttpContext.Session.SetString("UsuarioNombre", $"{empleado.Nombre} {empleado.Apellido}");
            HttpContext.Session.SetString("RolNombre", empleado.Rol?.NombreRol ?? "Sin Rol");

            // Redirigir al inventario de productos tras iniciar sesión con éxito
            return RedirectToAction("Index", "Productos");
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // Limpiar toda la sesión
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}