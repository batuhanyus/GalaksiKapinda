using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.Entities;
using Galaxy.PL.CoreMVC.Models.ViewModels.Account;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        IMailVerificationService mailVerificationService;
        public AccountController(IUserService usService, IMailVerificationService verifService)
        {
            userService = usService;
            mailVerificationService = verifService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            User user = userService.DoLogin(email, password);
            if (user != null)
            {
                HttpContext.Session.Set<int>("UserID", user.ID);
                HttpContext.Session.Set<int>("UserRole", user.UserType);

                if (!user.IsMailVerified)
                {
                    TempData["Message"] = "EMail verification required.";
                    return View("Index");
                }

                if (!user.IsPasswordValid)
                {
                    TempData["Message"] = "Change your password!";
                    return RedirectToAction("GetInfo", "Profile");
                }

                return RedirectToAction("Index", "Store");
            }
            else
            {
                TempData["Message"] = "No such user exist.";
                return RedirectToAction("Index");
            }
        }



        [HttpGet]
        public IActionResult Register()
        {
            AccountRegisterViewModel model = new();

            return View("Register", model);
        }

        [HttpPost]
        [Route("Account/Register")]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            if (!userService.Register(model.Name, model.Surname, model.EMail, model.Password1, model.Password2))
                TempData["Message"] = "Register failed.";
            else
            {
                string code = Guid.NewGuid().ToString();

                mailVerificationService.Insert(new MailVerification()
                {
                    MemberID = userService.GetByEmail(model.EMail).ID,
                    VerificatinCode = code.ToString()
                });

                MailHelper.SendMail(model.EMail, $"Welcome to Galaksi Kapında. Here is your activation code: {code}");

                TempData["Message"] = "Success.";
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult VerifyMail()
        {
            VerifyMailViewModel model = new();

            return View("VerifyMail", model);
        }

        [HttpPost]
        public IActionResult VerifyMail(VerifyMailViewModel model)
        {
            MailVerification mailVerification = mailVerificationService.GetByCode(model.Code);

            if (mailVerification.VerificatinCode == model.Code)
            {
                TempData["Message"] = "Success.";
                mailVerificationService.Delete(mailVerification);

                User old = userService.GetByEmail(model.EMail);
                User young = userService.GetByEmail(model.EMail);
                young.IsMailVerified = true;
                userService.Update(old, young);

            }
            else
                TempData["Message"] = "Success.";

            return View("VerifyMail", model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Account");
        }
    }
}
