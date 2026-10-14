using BL.Contracts;
using BL.Dtos;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    public class ShippingTypesController : Controller
    {
        private readonly IShippingType _shippingType;
        public ShippingTypesController(IShippingType shippingType)
        {
            _shippingType = shippingType;
        }

        [HttpGet]
        public IActionResult Index()
        {
           var shippingTypes = _shippingType.GetAll();
            return View(shippingTypes);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            // Add New
            if (Id == Guid.Empty)
            {
                return View(new ShippingTypeDto());
            }

            // Edit Existing
            var shippingType = _shippingType.GetById(Id);

            if (shippingType == null)
                return NotFound();

            return View(shippingType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ShippingTypeDto data)
        {
            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState)
                {
                    foreach (var error in item.Value.Errors)
                    {
                        Console.WriteLine($"{item.Key} : {error.ErrorMessage}");
                    }
                }

                return View("Edit", data);
            }

            if (data.Id == Guid.Empty)
            {
                _shippingType.Add(data, data.Id);
            }
            else
            {
                _shippingType.Update(data, data.Id);
            }
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(Guid Id)
        { 
            _shippingType.ChangeStatus(Id, Guid.NewGuid());
            
            return RedirectToAction(nameof(Index));
        }
    }
}
