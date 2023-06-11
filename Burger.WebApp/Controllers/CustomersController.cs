using BurgerStation.Business.Services;
using BurgerStation.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerStation.WebApp.Controllers
{
    public class CustomersController:Controller
    {
        private readonly CustomerService _customerService=new CustomerService();
        private readonly DistrictService _disctrictservice=new DistrictService();
        private readonly NeighborhoodService neighborhoodService=new NeighborhoodService();


        public IActionResult Create()
        {
            ViewBag.Districts = new SelectList(_disctrictservice.GetAll(), "Id", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerDto customer)
        {
            ViewBag.Districts = new SelectList(_disctrictservice.GetAll(), "Id", "Name");

            var result = _customerService.Create(customer);
            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return View();
            }
            else
            {
                ViewBag.Neigborhoods = _disctrictservice.GetAll();
                TempData["ResultMessage"] = result.Message;
                return View();
            }
        }
        public IActionResult GetByDistrictId(int Id)
        {
            var neighborhoods = neighborhoodService.GetAll();

            var neighborhoodbyDistrictId = neighborhoods.Where(m => m.DistrictId == Id);

            return Json(neighborhoodbyDistrictId);
        }

    }
}
