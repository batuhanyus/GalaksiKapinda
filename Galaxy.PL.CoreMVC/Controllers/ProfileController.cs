using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.BusinessLogic.Concrete;
using Galaxy.Entities;
using Galaxy.Entities.Location;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class ProfileController : Controller
    {
        IUserService userService;
        IOrderService orderService;
        ICreditCardService creditCardService;
        IAddressService addressService;

        public ProfileController(IUserService usService, IOrderService orService,
            ICreditCardService cardService, IAddressService addService)
        {
            userService = usService;
            orderService = orService;
            creditCardService = cardService;
            addressService = addService;
        }

        public IActionResult Index()
        {


            //return model;

            return View("Index");
        }

        [HttpGet]
        [Route("Profile/Info")]
        public IActionResult GetInfo()
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            User user = userService.GetByID(userID);
            ProfileMyInfoViewModel model = CreateModelFromUser(user);
            return View("MyInfo", model);
        }

        [HttpPost]
        [Route("Profile/Info")]
        public IActionResult EditInfo(ProfileMyInfoViewModel model)
        {
            User user = CreateUserFromModel(model);
            User oldEntity = userService.GetByID(user.ID);
            userService.Update(oldEntity, user);

            return RedirectToAction("GetInfo");
        }

        [Route("Profile/GetCreditCard")]
        public IActionResult GetCreditCard()
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            CreditCard card = creditCardService.GetCardByOwner(userID);
            ProfileCreditCardViewModel model = CreateModelFromCard(card);
            return View("CreditCardList", model);
        }

        [HttpGet]
        [Route("Profile/AddCreditCard")]
        public IActionResult AddCreditCard()
        {
            ProfileCreditCardViewModel model = new();
            return View("CreditCardAdd", model);
        }

        [HttpPost]
        [Route("Profile/AddCreditCard")]
        public IActionResult AddCreditCard(ProfileCreditCardViewModel model)
        {
            CreditCard card = CreateCardFromModel(model);
            creditCardService.Insert(card);
            return RedirectToAction("GetCreditCard");
        }

        [HttpGet]
        [Route("Profile/EditCreditCard")]
        public IActionResult EditCreditCard(int ID)
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            CreditCard card = creditCardService.GetByIDByOwner(userID, ID);
            ProfileCreditCardViewModel model = CreateModelFromCard(card);
            return View("CreditCardEdit", model);
        }

        [HttpPost]
        [Route("Profile/EditCreditCard")]
        public IActionResult EditCreditCard(ProfileCreditCardViewModel model)
        {
            CreditCard card = CreateCardFromModel(model);
            CreditCard oldEntity = creditCardService.GetByID(card.ID);
            creditCardService.Update(oldEntity, card);
            return RedirectToAction("GetCreditCard");
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

        CreditCard CreateCardFromModel(ProfileCreditCardViewModel model)
        {
            return new CreditCard()
            {
                ID = model.ID,
                CardHolderName = model.CardHolderName,
                CardNumber = model.CardNumber,
                CVC = model.CVC,
                ExpireDate = model.ExpireDate,
                MemberID = HttpContext.Session.Get<int>("UserID")
            };
        }

        ProfileCreditCardViewModel CreateModelFromCard(CreditCard card)
        {
            return new ProfileCreditCardViewModel()
            {
                ID = card.ID,
                CardHolderName = card.CardHolderName,
                CardNumber = card.CardNumber,
                CVC = card.CVC,
                ExpireDate = card.ExpireDate
            };
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

        User CreateUserFromModel(ProfileMyInfoViewModel model)
        {
            int userID = HttpContext.Session.Get<int>("UserID");

            User realUser = userService.GetByID(userID);

            User user = new User()
            {
                ID = userID,
                Mail = realUser.Mail,
                UserType = realUser.UserType,
                Name = model.Name,
                Surname = model.Surname
            };

            if (realUser.Password == model.OldPassword)
                user.Password = model.NewPassword;
            else
                user.Password = realUser.Password;

            return user;
        }

        ProfileMyInfoViewModel CreateModelFromUser(User user)
        {
            return new ProfileMyInfoViewModel()
            {
                EMail = user.Mail,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}
