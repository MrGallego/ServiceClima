using Microsoft.AspNetCore.Mvc;
using ServiceClima.Models;

namespace ServiceClima.Controllers
{
    public class ClimaController : Controller
    {
        private readonly DataContext _dataContext;
        public ClimaController(DataContext context)
        {
            _dataContext = context;
        }
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
            try
            {
                _dataContext.Add(clima);
                _dataContext.SaveChanges();
                TempData["msg"] = "Agregado";
                return RedirectToAction("AddClima");
            }
            catch (Exception ex )
            {
				TempData["msg"] = "No se agrego!";
				return View();
            }
        

		}
        public IActionResult DisplayClimas()
        {
            var climas = _dataContext.Climas.ToList();
            return View(climas);
        }

    }
}
