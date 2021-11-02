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

        public AccountController(IUserService usService)
        {
            userService = usService;
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
                    ViewBag.Message = "EMail verification required.";
                    return View("Index");
                }

                return RedirectToAction("Index", "Store");
            }
            else
            {
                ViewBag.Message = "No such user exist.";
                return RedirectToAction("Index");

                //user employee = user.DoLogin(email, password);

                //if (employee != null)
                //{
                //    HttpContext.Session.Set<int>("UserID", employee.ID);
                //    HttpContext.Session.Set<int>("UserRole", employee.UserType);

                //    return RedirectToAction("Index", "Store");
                //}
                //else
                //{
                //    ViewBag.Message = "No such user exist.";
                //    return RedirectToAction("Index");
                //}
            }
        }
    }
}
