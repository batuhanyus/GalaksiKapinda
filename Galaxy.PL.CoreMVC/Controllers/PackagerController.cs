using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.BusinessLogic.Concrete;
using Galaxy.Entities;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Packager;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class PackagerController : Controller
    {
        IOrderService orderService;
        IOrderDetailsService orderDetailsService;

        public PackagerController(IOrderService ordService, IOrderDetailsService ordetService)
        {
            orderService = ordService;
            orderDetailsService = ordetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Packager/GetOrders")]
        public IActionResult GetOrders()
        {
            List<PackagerOrderViewModel> model = new();
            ICollection<Order> orders = orderService.GetAll();

            foreach (Order order in orders)
            {
                model.Add(new PackagerOrderViewModel()
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

            return View("PackagerOrderList", model);
        }

    }
}
