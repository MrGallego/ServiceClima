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

            if (model.Email == "prueba@hotmail.com" && model.Password == "123456")
            {
                var url = Url.Action("AddClima", "Clima");

                // Redirigir al usuario a la URL generada
                return Redirect(url);
            }

            ModelState.AddModelError("", "Credenciales inválidas");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account"); // Redirige a la página principal después del cierre de sesión exitoso.
        }
    }
}
