using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServiceClima.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceClima.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Aquí debes realizar la validación de las credenciales de inicio de sesión.
            // Verificar el usuario y la contraseña en tu lógica de autenticación.

            if (model.Email == "usuario@example.com" && model.Password == "password")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                // Puedes agregar más claims según sea necesario
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Aquí puedes configurar las propiedades de autenticación, como la persistencia de la cookie, etc.
                    // Consulta la documentación de AuthenticationProperties para más opciones.
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("AddClima", "Clima"); // Redirige a la página principal después del inicio de sesión exitoso.
            }

            ModelState.AddModelError("", "Credenciales inválidas");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Redirige a la página principal después del cierre de sesión exitoso.
        }
    }
}
