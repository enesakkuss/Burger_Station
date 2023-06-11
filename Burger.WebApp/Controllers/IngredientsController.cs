using BurgerStation.Business.Services;
using BurgerStation.Ingredients;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace BurgerStation.WebApp.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IngredientService _ingredientService= new IngredientService();

        public IActionResult Index() 
        {
            var ingredients=_ingredientService.GetAll();
            return View(ingredients);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IngredientDto ingredient)
        {
            var commandResult=_ingredientService.Create(ingredient);

            if(commandResult.IsSuccess)
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
            var updateId = _ingredientService.GetById(id);
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
        public IActionResult Update(IngredientDto ingredient)
        {

            var commandResult = _ingredientService.Update(ingredient);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(ingredient);
            }
        }
        public IActionResult Delete(int id)
        {
            var ıngredient = _ingredientService.GetById(id);
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
        public IActionResult Delete(IngredientDto ingredient)
        {
            var commandResult = _ingredientService.Delete(ingredient);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(ingredient);
            }
        }
    }
}
