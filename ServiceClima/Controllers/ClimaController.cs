using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceClima.Models;
using System.Linq;

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
                _dataContext.Climas.Add(clima);
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

        public IActionResult UpdateClima (int id)
        {
            var clima = _dataContext.Climas.Find(id);
            return View(clima);
        }
        [HttpPost]
        public IActionResult UpdateClima(Clima clima)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                _dataContext.Climas.Update(clima);
                _dataContext.SaveChanges();
                return RedirectToAction("DisplayClimas");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "No se modifico!";
                return View();
            }


        }
        public IActionResult DeleteClima(int id)
        {
            try
            {
                var clima = _dataContext.Climas.Find(id);
                if (clima != null)
                {
                    _dataContext.Remove(clima);
                    _dataContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {


               
            }
            return RedirectToAction("DisplayClimas");

        }
    }
}
