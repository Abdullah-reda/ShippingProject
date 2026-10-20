using BL.Contracts;
using BL.Dtos;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Helpers;

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
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                {
                    _shippingType.Add(data, data.Id);
                }
                else
                {
                    _shippingType.Update(data, data.Id);
                }
                TempData["MessageType"] = MessageType.SaveSuccess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageType.SaveFailed;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            TempData["MessageType"] = null;

            try
            {
                _shippingType.ChangeStatus(id, Guid.NewGuid());
                TempData["MessageType"] = (int)MessageType.DeleteSuccess;
            }
            catch (Exception)
            {
                TempData["MessageType"] = (int)MessageType.DeleteFailed;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
