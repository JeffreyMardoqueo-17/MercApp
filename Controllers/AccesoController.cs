using Microsoft.AspNetCore.Mvc;
using MercApp.Data;
using MercApp.Models;
using Microsoft.EntityFrameworkCore;
using MercApp.ViewModels;
using Microsoft.Extensions.Logging; // Para logging
using BCrypt.Net; // Para la encriptación

namespace MercApp.Controllers
{
    public class AccesoController : Controller
    {
        // Configurar el acceso a la BD
        private readonly AppDbContext _appDBContext;
        private readonly ILogger<AccesoController> _logger; // Inyección de un logger

        public AccesoController(AppDbContext appContext, ILogger<AccesoController> logger)
        {
            _appDBContext = appContext;
            _logger = logger;
        }

        // Ruta para registrarse
        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM modelo)
        {
            // Validar que las contraseñas coincidan
            if (modelo.Pass != modelo.ConfirmarPass)
            {
                ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                return View(modelo);
            }

            try
            {
                // Verificar si el correo ya está registrado
                if (await _appDBContext.Usuarios.AnyAsync(u => u.Email == modelo.Email))
                {
                    ModelState.AddModelError(string.Empty, "El correo electrónico ya está registrado");
                    return View(modelo);
                }

                // Crear un nuevo objeto Usuario
                var usuario = new Usuario
                {
                    Nombre = modelo.Nombre,
                    Apellido = modelo.Apellido,
                    Telefono = modelo.Telefono,
                    Email = modelo.Email,
                    Pass = BCrypt.Net.BCrypt.HashPassword(modelo.Pass), // Encriptar la contraseña
                    FechaRegistro = DateTime.Now,
                    IdGenero = modelo.IdGenero,
                    IdRol = modelo.IdRol
                };

                // Agregar el usuario a la base de datos
                await _appDBContext.Usuarios.AddAsync(usuario);
                await _appDBContext.SaveChangesAsync();

                // Redireccionar al login si la creación del usuario fue exitosa
                return RedirectToAction("Login", "Acceso");
            }
            catch (Exception ex)
            {
                // Registrar el error usando ILogger
                _logger.LogError(ex, "Error al intentar registrar el usuario");

                // Mensaje de error para el usuario
                ModelState.AddModelError(string.Empty, "Ocurrió un error al intentar registrar el usuario. Por favor, inténtalo de nuevo.");
            }

            // Devolver la vista con el modelo para mantener los datos ingresados
            return View(modelo);
        }
    }
}
