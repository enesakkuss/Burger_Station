using BurgerStation.Business.Services;
using BurgerStation.Categories;
using BurgerStation.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace BurgerStation.WebApp.Controllers
{
    public class CategoriesController:Controller
    {
        private readonly CategoryService _categoryService=new CategoryService();

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDto category)
        {
            var commandResult = _categoryService.Create(category);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = commandResult.Message;
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var updateId = _categoryService.GetById(id);
            if (updateId != null)
            {
                return View(updateId);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(CategoryDto category)
        {

            var commandResult = _categoryService.Update(category);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(category);
            }
        }
        public IActionResult Delete(int id)
        {
            var ıngredient = _categoryService.GetById(id);
            if (ıngredient != null)
            {
                return View(ıngredient);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(CategoryDto category)
        {
            var commandResult = _categoryService.Delete(category);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(category);
            }
        }
    }
}
