using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.Entities;

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

                if(!user.IsPasswordValid)
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
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(string name, string surname, string email, string password1, string password2)
        {
            if (!userService.Register(name, surname, email, password1, password2))
                TempData["Message"] = "Register failed.";
            else
            {
                Random random = new();
                string code = Guid.NewGuid().ToString();

                mailVerificationService.Insert(new MailVerification()
                {
                    MemberID = userService.GetByEmail(email).ID,
                    VerificatinCode = code.ToString()
                });

                MailHelper.SendMail(email, $"Welcome to Galaksi Kapında. Here is your activation code: {code}");
                TempData["Message"] = "Success.";
            }

            return View("Login", new { email = email, password = password1 });
        }

        [HttpGet]
        public IActionResult VerifyMail()
        {
            return View("VerifyMail");
        }

        [HttpPost]
        public IActionResult VerifyMail(string mail, string code)
        {
            MailVerification mailVerification = mailVerificationService.GetByCode(mail);

            if (mailVerification.VerificatinCode == code)
            {
                TempData["Message"] = "Success.";
                mailVerificationService.Delete(mailVerification);
            }
            else
                TempData["Message"] = "Success.";

            return View("VerifyMail");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
