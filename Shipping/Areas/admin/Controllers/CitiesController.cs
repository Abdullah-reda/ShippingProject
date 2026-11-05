using BL.Contracts;
using BL.Dtos;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly ICity _ICity;
        private readonly ICountry _ICountry;
        public CitiesController(ICity ICity, ICountry iCountry)
        {
            _ICity = ICity;
            _ICountry = iCountry;
        }
        public IActionResult Index()
        {
            var data = _ICity.GitAllCitites();
            return View(data);
        }

        public IActionResult Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data=new BL.Dtos.CityDto();
            LoadCountries();
            if (Id != null)
            {
                data = _ICity.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CityDto data)
        {
            if (!ModelState.IsValid)
            {
                LoadCountries();
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                {
                    _ICity.Add(data, data.Id);
                }
                else
                {
                    _ICity.Update(data, data.Id);
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
                _ICity.ChangeStatus(id, Guid.NewGuid());
                TempData["MessageType"] = (int)MessageType.DeleteSuccess;
            }
            catch (Exception)
            {
                TempData["MessageType"] = (int)MessageType.DeleteFailed;
            }

            return RedirectToAction(nameof(Index));
        }

        void LoadCountries()
        {
            ViewBag.Countries = _ICountry.GetAll() ?? Enumerable.Empty<CountryDto>();
        }
    }
}
