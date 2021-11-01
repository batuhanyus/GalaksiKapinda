using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.BusinessLogic.Concrete;
using Galaxy.Entities.UserTypes;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class ProfileController : Controller
    {
        IMemberService memberService;
        IEmployeeService employeeService;

        public ProfileController(IMemberService memService, IEmployeeService empService)
        {
            memberService = memService;
            employeeService = empService;
        }

        public IActionResult Index(ProfileMainViewModel model)
        {
            if (model == null)
                ShowInfo();

            return View("Index", model);
        }

        public IActionResult ShowInfo()
        {
            ProfileMainViewModel model = PrepareMyInfo();

            return RedirectToAction("Index", model);
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult OrderDetails()
        {
            return View();
        }

        public IActionResult Addresses()
        {
            return View();
        }

        public IActionResult AddressDetails()
        {
            return View();
        }

        public IActionResult CreditCards()
        {
            return View();
        }

        public IActionResult CreditCardDetails()
        {
            return View();
        }

        ProfileMainViewModel PrepareMyInfo()
        {
            ProfileMainViewModel model = new()
            {
                ContentType = "MyInfo",
                MyInfoViewModel = new()
            };

            int userRole = HttpContext.Session.Get<int>("UserRole");
            int userID = HttpContext.Session.Get<int>("UserID");

            Member member;
            Employee employee;
            if (userRole == 0)
            {
                member = memberService.GetByID(userID);
                model.MyInfoViewModel.EMail = member.Mail;
                model.MyInfoViewModel.Name = member.Name;
                model.MyInfoViewModel.Surname = member.Surname;
            }
            else
            {
                employee = employeeService.GetByID(userID);
                model.MyInfoViewModel.EMail = employee.Mail;
                model.MyInfoViewModel.Name = employee.Name;
                model.MyInfoViewModel.Surname = employee.Surname;
            }  

            return model;
        }


    }
}
