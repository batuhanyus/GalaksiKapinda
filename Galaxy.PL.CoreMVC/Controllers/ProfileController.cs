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

        public IActionResult Index(string contentType = "MyInfo")
        {
            ProfileMainViewModel model = new();

            switch (contentType)
            {
                case "MyInfo":
                    model = PrepareMyInfo();
                    break;
                case "OrderList":
                    model = PrepareOrders();
                    break;
                case "AddressList":

                    break;
                case "CreditCardList":

                    break;
                default:
                    break;
            }

            return View("Index", model);
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

            dynamic user;
            if (userRole == 0)
                user = memberService.GetByID(userID);
            else
                user = employeeService.GetByID(userID);

            model.MyInfoViewModel.EMail = user.Mail;
            model.MyInfoViewModel.Name = user.Name;
            model.MyInfoViewModel.Surname = user.Surname;

            return model;
        }

        ProfileMainViewModel PrepareOrders()
        {
            ProfileMainViewModel model = new()
            {
                ContentType = "OrderList",
                MyInfoViewModel = new()
            };

            return model;
        }
    }
}
