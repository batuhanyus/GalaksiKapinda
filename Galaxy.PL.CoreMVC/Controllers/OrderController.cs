using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        IOrderDetailsService orderDetailsService;
        IAddressService addressService;
        IUserService userService;

        public OrderController(IOrderService ordService, IOrderDetailsService ordetService, IAddressService addService, IUserService usrService)
        {
            orderService = ordService;
            orderDetailsService = ordetService;
            addressService = addService;
            userService = usrService;
        }

        bool Auth()
        {
            if (!AuthHelper.CanAccess(HttpContext.Session.Get<int>("UserRole"), new int[] { 4, 3, 2, 1 }))
                return false;
            else
                return true;
        }

        public IActionResult Index()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            return RedirectToAction("GetOrders");
        }

        [Route("Order/GetOrders")]
        public IActionResult GetOrders()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            int userID = HttpContext.Session.Get<int>("UserID");
            List<OrderViewModel> model = new();
            ICollection<Order> orders = orderService.GetOrdersByUser(userID);

            foreach (Order order in orders)
            {
                model.Add(new OrderViewModel()
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

            return View("OrderList", model);
        }

        [Route("Order/GetDetails")]
        public IActionResult GetDetails(int orderID)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            OrderViewModel model = new();

            Order order = orderService.GetByID(orderID);
            ICollection<OrderDetails> ods = orderDetailsService.GetOrderDetailsByOrderID(orderID);
            model.Details = ods.ToList();
            model.OrderID = order.ID;
            model.OrderStatus = order.OrderStatus;

            try
            {
                User deliverer = userService.GetByID(order.DelivererID);
                model.DelivererName = $"{deliverer.Name} {deliverer.Surname}";
            }
            catch (Exception)
            {

            }

            

            return View("OrderDetails", model);
        }
    }
}
