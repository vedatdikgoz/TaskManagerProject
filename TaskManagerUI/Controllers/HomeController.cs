using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagerBusiness.Abstract;
using TaskManagerEntities.Concrete;
using TaskManagerUI.Models;

namespace TaskManagerUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IGorevService _gorevService;
        public HomeController(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }

        public IActionResult Index()
        {
            return View();
        }

            
       
        public IActionResult AllTasks()
        {
            var gorevViewModel = new GorevViewModel()
            {
                Gorevler = _gorevService.GetAll().OrderBy(g=>g.ExpiredDate).ToList()

            };
            return View(gorevViewModel);
        }

          

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddTask(GorevAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var gorev = new Gorev()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Status=model.Status,
                    CreatedDate = model.CreatedDate,
                    ExpiredDate = model.ExpiredDate
                };
                _gorevService.Add(gorev);                                
                return RedirectToAction("DailyTasks");                              
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            var gorev = _gorevService.GetById(id);
            if(gorev == null)
            {
                return RedirectToAction("Index","Home");
            }
            var model = new GorevUpdateViewModel()
            {
                Id = gorev.Id,
                Name = gorev.Name,
                Description = gorev.Description,
                Status = gorev.Status,
                CreatedDate = gorev.CreatedDate,
                ExpiredDate = gorev.ExpiredDate

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateTask(GorevUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var gorev = _gorevService.GetById(model.Id);
                if (gorev == null)
                {
                    return NotFound();
                }

                gorev.Name = model.Name;
                gorev.Description = model.Description;
                gorev.Status = model.Status;
                gorev.CreatedDate = model.CreatedDate;
                gorev.ExpiredDate = model.ExpiredDate;


                _gorevService.Update(gorev);
                
                return RedirectToAction("Index","Home");
                           
            }         
            return View(model);
        }


        public IActionResult DeleteTask(int id)
        {
            var gorev = _gorevService.GetById(id);
            if (gorev != null)
            {
                _gorevService.Delete(gorev);
                return RedirectToAction("DailyTasks", "Home");
            }
          
            return RedirectToAction("DailyTasks", "Home");
        }
    }
}