using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class CreditCardController : Controller
    {

        ICreditCardService creditCardService;

        public CreditCardController(ICreditCardService cardService)
        {
            creditCardService = cardService;
        }

        [Route("Profile/GetCreditCard")]
        public IActionResult GetCreditCard()
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            CreditCard card = creditCardService.GetCardByOwner(userID);
            if (card == null)
                return View("CreditCardAdd", new ProfileCreditCardViewModel());

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
    }
}
