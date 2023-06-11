using BurgerStation.Business.Services;
using BurgerStation.Categories;
using BurgerStation.FinalOrders;
using Microsoft.AspNetCore.Mvc;

namespace BurgerStation.WebApp.Controllers
{
    
    public class FinalOrdersController:Controller
    {
        private readonly FinalOrderService _finalOrderService = new FinalOrderService();
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FinalOrderDto finalOrder)
        {
            var commandResult = _finalOrderService.Create(finalOrder);

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
    }
}
