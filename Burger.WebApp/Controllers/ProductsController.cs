using BurgerStation.Business;
using BurgerStation.Business.Services;
using BurgerStation.Domain;
using BurgerStation.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerStation.WebApp.Controllers
{
    public class ProductsController:Controller
    {
        private readonly ProductService _productService = new ProductService();
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly IngredientService _ingredientService=new IngredientService();

        public IActionResult Index()
        { 
            var products = _productService.GetSummaries();
            return View(products);
        }

        public IActionResult Create()
        {
            LoadExtraModels();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto product)
        {
            LoadExtraModels();

            var result = _productService.Create(product);
            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadExtraModels();
                TempData["ResultMessage"] = result.Message;
                return View();
            }
        }
        public IActionResult Delete(ProductDto productDto)
        {
            var commandResult = _productService.Delete(productDto);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var product = _productService.GetById(id);

            
            if (product != null)
            {
                LoadExtraModels();

                return View(product);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Update(ProductDto product)
        {
            var commandResult = _productService.Update(product);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadExtraModels();
                TempData["ResultMessage"] = commandResult.Message;
                return View(product);
            }
        }
        private void LoadExtraModels()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            ViewBag.Ingredients= new SelectList( _ingredientService.GetAll(),"Id","Name");
        }
        private void LoadExtraModels2()
        {
            var categories = _categoryService.GetAll()
                .Select(c => new SelectListItem
                {
                     Value = c.Id.ToString(),
                     Text = c.Name
                })
                    .ToList();
            ViewBag.Categories = categories;
            ViewBag.Ingredients = new SelectList(_ingredientService.GetAll(), "Id", "Name");
        }
    }
}
