using BL.Contracts;
using BL.Dtos;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Helpers;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    public class CountresController : Controller
    {
        private readonly ICountry _icountry;
        public CountresController(ICountry icountry)
        {
            _icountry = icountry;
        }

        [HttpGet]
        public IActionResult Index()
        {
           var countres = _icountry.GetAll();
            return View(countres);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            // Add New
            if (Id == Guid.Empty)
            {
                return View(new CountryDto());
            }

            // Edit Existing
            var country = _icountry.GetById(Id);

            if (country == null)
                return NotFound();

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( CountryDto data)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                {
                    _icountry.Add(data, data.Id);
                }
                else
                {
                    _icountry.Update(data, data.Id);
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
                _icountry.ChangeStatus(id, Guid.NewGuid());
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
