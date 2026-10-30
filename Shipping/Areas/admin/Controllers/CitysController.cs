using BL.Contracts;
using BL.Dtos;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class CitysController : Controller
    {
        private readonly ICity _icity;
        private readonly ICountry _icountry;
        public CitysController(ICity icity, ICountry icountry)
        {
            _icity = icity;
            _icountry = icountry;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var citys = _icity.GetAll();
            return View(citys);
        }
        private void LoadCountries(Guid? selectedCountryId = null)
        {
            var countries = _icountry.GetAll();

            ViewBag.Countries = new SelectList(
                countries,
                "Id",
                "CountryEname",
                selectedCountryId
            );
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                LoadCountries();
                return View(new CityDto());
            }

            var city = _icity.GetById(Id);

            if (city == null)
                return NotFound();

            LoadCountries(city.CountryId);

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CityDto data)
        {
            if (!ModelState.IsValid)
            {
                LoadCountries(data.CountryId);
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                {
                    _icity.Add(data, data.Id);
                }
                else
                {
                    _icity.Update(data, data.Id);
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
                _icity.ChangeStatus(id, Guid.NewGuid());
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
