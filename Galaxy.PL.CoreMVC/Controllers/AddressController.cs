using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities.Location;
using Galaxy.PL.CoreMVC.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Galaxy.PL.CoreMVC.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class AddressController : Controller
    {
        IAddressService addressService;
        ICityService cityService;
        ICountyService countyService;

        public AddressController(IAddressService addService, ICityService cityService, ICountyService countyService)
        {
            addressService = addService;
            this.cityService = cityService;
            this.countyService = countyService;
        }

        bool Auth()
        {
            if (!AuthHelper.CanAccess(HttpContext.Session.Get<int>("UserRole"), new int[] { 3, 2, 1, 0 }))
                return false;
            else
                return true;
        }

        [Route("Address/GetAddresses")]
        public IActionResult GetAddresses()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            List<ProfileAddressViewModel> model = new();
            int userID = HttpContext.Session.Get<int>("UserID");
            ICollection<Address> addresses = addressService.GetByOwner(userID);
            foreach (Address item in addresses)
            {
                model.Add(CreateModelFromAddress(item));
            }
            return View("AddressList", model);
        }

        [HttpGet]
        [Route("Address/EditAddress")]
        public IActionResult EditAddress(int ID)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            int userID = HttpContext.Session.Get<int>("UserID");
            Address address = addressService.GetByIDByOwner(userID, ID);
            ProfileAddressViewModel model = CreateModelFromAddress(address);
            return View("AddressEdit", model);
        }

        [HttpPost]
        [Route("Address/EditAddress")]
        public IActionResult EditAddress(ProfileAddressViewModel model)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            Address address = CreateAddressFromModel(model);
            Address oldEntity = addressService.GetByID(address.ID);
            addressService.Update(oldEntity, address);
            return RedirectToAction("GetAddresses");
        }

        [HttpGet]
        [Route("Address/AddAddress")]
        public IActionResult AddAddress(int cityID)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            ProfileAddressViewModel model = new();
            model.CityID = cityID;
            model.Cities = CreateCityList();
            model.Counties = CreateCountyList(cityID);
            return View("AddressAdd", model);
        }

        [HttpPost]
        [Route("Address/AddAddress")]
        public IActionResult AddAddress(ProfileAddressViewModel model)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            Address address = CreateAddressFromModel(model);
            addressService.Insert(address);
            return RedirectToAction("GetAddresses");
        }

        [Route("Address/SelectCity")]
        [HttpGet]
        public IActionResult SelectCity(int ID = 0) //Address ID
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            ProfileAddressViewModel model = new();
            model.Cities = CreateCityList();

            if (ID == 0)
                model.OpType = 0;
            else
            {
                model.OpType = 1;
                model.ID = ID;
            }

            return View("AddressSelectCity", model);
        }

        [Route("Address/SelectCity")]
        [HttpPost]
        public IActionResult SelectCity(ProfileAddressViewModel model)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            City city = cityService.GetByID(model.CityID);

            model.SelectedCityID = model.SelectedCityID;
            model.Counties = CreateCountyList(model.SelectedCityID);
            model.CityID = model.SelectedCityID;

            if (model.OpType == 0)
                return RedirectToAction("AddAddress", new { cityID = model.SelectedCityID });
            else
                return RedirectToAction("EditAddress", new { ID = model.ID });
        }

        Address CreateAddressFromModel(ProfileAddressViewModel model)
        {
            return new Address()
            {
                ID = model.ID,
                Name = model.Name,
                AdressDetails = model.AdressDetails,
                AdressNotes = model.AdressNotes,
                CityID = model.CityID,
                CountyID = model.CountyID,
                MemberID = HttpContext.Session.Get<int>("UserID")
            };
        }

        ProfileAddressViewModel CreateModelFromAddress(Address address)
        {
            return new ProfileAddressViewModel()
            {
                ID = address.ID,
                CityID = address.CityID,
                CountyID = address.CountyID,
                AdressDetails = address.AdressDetails,
                AdressNotes = address.AdressNotes,
                Name = address.Name,
                Cities = CreateCityList(),
            };
        }


        List<SelectListItem> CreateCityList()
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            List<City> dbCities = cityService.GetAll().ToList();

            foreach (City city in dbCities)
            {
                cities.Add(new SelectListItem() { Value = (dbCities.IndexOf(city) + 1).ToString(), Text = city.Name });
            }

            return cities;
        }

        List<SelectListItem> CreateCountyList(int cityID)
        {
            List<SelectListItem> counties = new List<SelectListItem>();
            List<County> dbcounties = countyService.GetCountiesByCityID(cityID).ToList();

            foreach (County county in dbcounties)
            {
                counties.Add(new SelectListItem() { Value = (dbcounties.IndexOf(county) + 1).ToString(), Text = county.Name });
            }

            return counties;
        }
    }
}
