using BurgerStation.Business.Services;
using BurgerStation.Domain;
using BurgerStation.Orders;
using BurgerStation.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerStation.WebApp.Controllers
{
    public class OrdersController:Controller
    {
        private readonly OrderService _orderService=new OrderService();
        private readonly ProductService _productService = new ProductService();
        private readonly CustomerService _customerService = new CustomerService();
        private readonly IngredientService _ingredientService = new IngredientService();
        public IActionResult Index()
        {
            var products = _productService.GetSummaries();
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(int[] selectedProducts)
        {
            if (selectedProducts != null && selectedProducts.Length > 0)
            {

                var orderDto = new OrderDto
                {
                    Products = selectedProducts
                };

                var result = _orderService.Create(orderDto);

                if (result.IsSuccess)
                {
                    TempData["OrderId"] = result.OrderId;
                    TempData["ResultMessage"] = result.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ResultMessage"] = result.Message;
                    return View();
                }
            }


            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(int id)
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
        public IActionResult OrderDetails()
        {
            var id = (int)TempData["OrderId"];
            var order = _orderService.GetById(id);
            if (order != null)
            {
                ViewBag.OrderProducts = order.Products;
                return View(order);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }

        }

        private void LoadExtraModels()
        {
            ViewBag.Ingredients = new SelectList(_ingredientService.GetAll(), "Id", "Name");

            
        }
    }
}
