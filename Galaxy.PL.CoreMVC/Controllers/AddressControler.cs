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

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class AddressControler : Controller
    {
        IAddressService addressService;

        public AddressControler(IAddressService addService)
        {
            addressService = addService;
        }

        [Route("Profile/GetAddresses")]
        public IActionResult GetAddresses()
        {
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
        [Route("Profile/EditAddress")]
        public IActionResult EditAddress(int ID)
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            Address address = addressService.GetByIDByOwner(userID, ID);
            ProfileAddressViewModel model = CreateModelFromAddress(address);
            return View("AddressEdit", model);
        }

        [HttpPost]
        [Route("Profile/EditAddress")]
        public IActionResult EditAddress(ProfileAddressViewModel model)
        {
            Address address = CreateAddressFromModel(model);
            Address oldEntity = addressService.GetByID(address.ID);
            addressService.Update(oldEntity, address);
            return RedirectToAction("GetAddresses");
        }


        [HttpGet]
        [Route("Profile/AddAddress")]
        public IActionResult AddAddress()
        {
            ProfileAddressViewModel model = new();
            return View("AddressAdd", model);
        }

        [HttpPost]
        [Route("Profile/AddAddress")]
        public IActionResult AddAddress(ProfileAddressViewModel model)
        {
            Address address = CreateAddressFromModel(model);
            addressService.Insert(address);
            return RedirectToAction("GetAddresses");
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
                Name = address.Name
            };
        }
    }
}
