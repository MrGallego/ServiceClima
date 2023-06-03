using Microsoft.AspNetCore.Mvc;
using ServiceClima.Models;

namespace ServiceClima.Controllers
{
    public class ClimaController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    
        public IActionResult AddClima()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClima(Clima clima)
        {
            if (!ModelState.IsValid)
            {
				return View();

			}
            TempData["msg"] = "Agregado";
            return View();
		}

    }
}
