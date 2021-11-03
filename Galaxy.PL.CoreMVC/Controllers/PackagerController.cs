using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.BusinessLogic.Concrete;
using Galaxy.Entities;
using Galaxy.Entities.Location;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Order;
using Galaxy.PL.CoreMVC.Models.ViewModels.Packager;
using Galaxy.PL.CoreMVC.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class PackagerController : Controller
    {
        IOrderService orderService;
        IOrderDetailsService orderDetailsService;
        IUserService userService;
        IAddressService addressService;

        public PackagerController(IOrderService ordService, IOrderDetailsService ordetService, IUserService usrService, IAddressService addService)
        {
            orderService = ordService;
            orderDetailsService = ordetService;
            userService = usrService;
            addressService = addService;
        }

        bool Auth()
        {
            if (!AuthHelper.CanAccess(HttpContext.Session.Get<int>("UserRole"), new int[] { 4, 3 }))
                return false;
            else
                return true;
        }

        public IActionResult Index()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            return RedirectToAction("GetOrders");
        }

        [Route("Packager/GetOrders")]
        public IActionResult GetOrders()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            List<PackagerOrderViewModel> model = new();
            ICollection<Order> orders = orderService.GetAll();

            foreach (Order order in orders)
            {
                model.Add(new PackagerOrderViewModel()
                {
                    AddressID = order.AddressID,
                    DelivererID = order.DelivererID,
                    MemberID = order.MemberID,
                    OrderID = order.ID,
                    OrderStatus = order.OrderStatus,
                    PackagerID = order.PackagerID,
                    Details = orderDetailsService.GetOrderDetailsByOrderID(order.ID).ToList()
                });
            }

            return View("PackagerOrderList", model);
        }

        [Route("Packager/GetDetails")]
        public IActionResult GetDetails(int orderID)
        {
            Order order = orderService.GetByID(orderID);
            PackagerOrderViewModel model = CreateModelFromOrder(order);

            return View("PackagerOrderDetails", model);
        }

        [HttpPost]
        [Route("Packager/AssignDeliverer")]
        public IActionResult AssignDeliverer(PackagerOrderViewModel model)
        {
            Order old = orderService.GetByID(model.OrderID);
            Order young = CreateOrderFromModel(model);
            orderService.Update(old, young);

            return RedirectToAction("GetDetails", new { model.OrderID });
        }

        List<SelectListItem> CreateDelivererList()
        {
            ICollection<User> dbDeliverers = userService.GetAllDeliverers();
            List<SelectListItem> deliverers = new();

            foreach (User deliverer in dbDeliverers)
            {
                deliverers.Add(new SelectListItem()
                {
                    Value = deliverer.ID.ToString(),
                    Text = deliverer.Name + " " + deliverer.Surname
                });
            }

            return deliverers;
        }

        Order CreateOrderFromModel(PackagerOrderViewModel model)
        {
            return new Order()
            {
                ID = model.OrderID,
                AddressID = model.AddressID,
                DelivererID = model.DelivererID,
                MemberID = model.MemberID,
                OrderStatus = model.OrderStatus,
                PackagerID = model.PackagerID
            };
        }

        PackagerOrderViewModel CreateModelFromOrder(Order order)
        {
            return new PackagerOrderViewModel()
            {
                PackagerID = order.PackagerID,
                OrderID = order.ID,
                OrderStatus = order.OrderStatus,
                MemberID = order.MemberID,
                DelivererID = order.DelivererID,
                AddressID = order.AddressID,
                Deliverers = CreateDelivererList(),
                OrderStatuses = CreateOrderStatuses(),
                Details = orderDetailsService.GetOrderDetailsByOrderID(order.ID).ToList()
            };
        }

        private List<SelectListItem> CreateOrderStatuses()
        {
            List<SelectListItem> statuses = new();

            statuses.Add(new SelectListItem()
            {
                Value = "Preparing",
                Text = "Preparing"
            });

            statuses.Add(new SelectListItem()
            {
                Value = "On Delivery",
                Text = "On Delivery"
            });

            return statuses;
        }
    }
}
