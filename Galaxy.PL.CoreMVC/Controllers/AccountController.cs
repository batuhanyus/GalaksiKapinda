using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities.UserTypes;
using Microsoft.AspNetCore.Mvc;
using Galaxy.PL.CoreMVC.Helpers;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class AccountController : Controller
    {
        IMemberService memberService;
        IEmployeeService employeeService;

        public AccountController(IMemberService memService, IEmployeeService empService)
        {
            memberService = memService;
            employeeService = empService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            Member member = memberService.DoLogin(email, password);
            if (member != null)
            {
                HttpContext.Session.Set<int>("UserID", member.ID);
                HttpContext.Session.Set<int>("UserRole", member.UserType);                

                if (!member.IsMailVerified)
                {
                    ViewBag.Message = "EMail verification required.";
                    return View("Index");
                }

                return RedirectToAction("Index", "Store");
            }
            else
            {
                Employee employee = employeeService.DoLogin(email, password);

                if (employee != null)
                {
                    HttpContext.Session.Set<int>("UserID", employee.ID);
                    HttpContext.Session.Set<int>("UserRole", employee.UserType);

                    return RedirectToAction("Index", "Store");
                }
                else
                {
                    ViewBag.Message = "No such user exist.";
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
