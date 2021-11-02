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

        public ProfileController(IUserService usService)
        {
            userService = usService;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("Profile/GetInfo")]
        public IActionResult GetInfo()
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            User user = userService.GetByID(userID);
            ProfileMyInfoViewModel model = CreateModelFromUser(user);
            return View("MyInfo", model);
        }

        [HttpPost]
        [Route("Profile/EditInfo")]
        public IActionResult EditInfo(ProfileMyInfoViewModel model)
        {
            User user = CreateUserFromModel(model);
            User oldEntity = userService.GetByID(user.ID);
            if (userService.Update(oldEntity, user) > 0)
                TempData["Message"] = "Success!";

            return RedirectToAction("GetInfo");
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
                IsPasswordValid = realUser.IsPasswordValid,
                IsMailVerified = realUser.IsMailVerified,
                Phone = realUser.Phone,
                BirthDate = realUser.BirthDate,
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
                Surname = user.Surname,
                UserID = user.ID
            };
        }
    }
}
