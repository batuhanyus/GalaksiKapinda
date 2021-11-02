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

        public OrderController(IOrderService ordService, IOrderDetailsService ordetService)
        {
            orderService = ordService;
            orderDetailsService = ordetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Order/GetOrders")]
        public IActionResult GetOrders()
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            List<OrderViewModel> model = new();
            ICollection<Order> orders = orderService.GetOrdersByUser(userID);

            foreach (Order order in orders)
            {
                model.Add(new OrderViewModel()
                {
                    CityID = order.CityID,
                    CountyID = order.CountyID,
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
            OrderViewModel model = new();

            Order order =orderService.GetByID(orderID);
            ICollection<OrderDetails> ods = orderDetailsService.GetOrderDetailsByOrderID(orderID);
            model.Details = ods.ToList();
            model.OrderID = order.ID;
            model.OrderStatus = order.OrderStatus;

            return View("OrderDetails", model);
        }
    }
}
