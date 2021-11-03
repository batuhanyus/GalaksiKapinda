using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Deliverer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class DelivererController : Controller
    {
        IOrderService orderService;
        IOrderDetailsService orderDetailsService;
        IUserService userService;

        public DelivererController(IOrderService ordService, IOrderDetailsService ordetService, IUserService usrService)
        {
            orderService = ordService;
            orderDetailsService = ordetService;
            userService = usrService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetDeliveries");
        }

        [Route("Deliverer/GetDeliveries")]
        public IActionResult GetDeliveries()
        {
            List<DelivererOrderViewModel> model = new();
            int userID = HttpContext.Session.Get<int>("UserID");
            ICollection<Order> orders = orderService.GetOrdersByDelivererID(userID);

            foreach (Order order in orders)
            {
                model.Add(new DelivererOrderViewModel()
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

            return View("DelivererOrderList", model);
        }

        [Route("Deliverer/GetDetails")]
        public IActionResult GetDetails(int orderID)
        {
            Order order = orderService.GetByID(orderID);
            DelivererOrderViewModel model = CreateModelFromOrder(order);

            return View("DelivererOrderDetails", model);
        }

        [HttpPost]
        [Route("Deliverer/UpdateDelivery")]
        public IActionResult UpdateDelivery(DelivererOrderViewModel model)
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

        Order CreateOrderFromModel(DelivererOrderViewModel model)
        {
            return new Order()
            {
                ID = model.OrderID,
                CityID = model.CityID,
                CountyID = model.CountyID,
                DelivererID = model.DelivererID,
                MemberID = model.MemberID,
                OrderStatus = model.OrderStatus,
                PackagerID = model.PackagerID
            };
        }

        DelivererOrderViewModel CreateModelFromOrder(Order order)
        {
            return new DelivererOrderViewModel()
            {
                PackagerID = order.PackagerID,
                OrderID = order.ID,
                OrderStatus = order.OrderStatus,
                MemberID = order.MemberID,
                DelivererID = order.DelivererID,
                CountyID = order.CountyID,
                CityID = order.CityID,
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
                Value = "Delivered",
                Text = "Delivered"
            });

            statuses.Add(new SelectListItem()
            {
                Value = "Incorrect Address",
                Text = "Incorrect Address"
            });

            statuses.Add(new SelectListItem()
            {
                Value = "Member Was Not Found",
                Text = "Member Was Not Found"
            });

            return statuses;
        }

    }
}
