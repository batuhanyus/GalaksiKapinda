using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities;
using Galaxy.Entities.Location;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class CartController : Controller
    {
        IProductService productService;
        ICreditCardService creditCardService;
        IOrderService orderService;
        IOrderDetailsService orderDetailsService;
        IAddressService addressService;

        public CartController(IProductService prodService, ICreditCardService credService, IOrderService ordService, 
            IAddressService addService,IOrderDetailsService odService)
        {
            productService = prodService;
            creditCardService = credService;
            orderService = ordService;
            addressService = addService;
            orderDetailsService = odService;
        }

        bool Auth()
        {
            if (!AuthHelper.CanAccess(HttpContext.Session.Get<int>("UserRole"), new int[] { 3, 2, 1, 0 }))
                return false;
            else
                return true;
        }

        public IActionResult Index()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            List<CartItem> cartContents = cartContents = HttpContext.Session.Get<List<CartItem>>("Cart");
            if (cartContents == null)
                cartContents = new();

            return View(cartContents);
        }

        [HttpGet]
        public IActionResult AddToCart(int categoryID, int productID)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            Product p = productService.GetByID(productID);

            if (p != null)
            {
                List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("Cart");
                if (cart != null)
                {
                    CartItem cartItem = cart.SingleOrDefault(a => a.ProductID == p.ID);
                    if (cartItem != null)
                    {
                        cartItem.Quantity++;
                    }
                    else
                    {
                        cartItem = new CartItem()
                        {
                            ProductID = p.ID,
                            Name = p.Name,
                            Price = p.Price,
                            Quantity = 1
                        };
                        cart.Add(cartItem);
                    }
                }
                else
                {
                    cart = new List<CartItem>();
                    CartItem cartItem = new CartItem()
                    {
                        ProductID = p.ID,
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = 1
                    };
                    cart.Add(cartItem);
                }

                HttpContext.Session.Set<List<CartItem>>("Cart", cart);

                decimal cartTotal = 0m;
                foreach (CartItem item in cart)
                {
                    cartTotal += item.Price * item.Quantity;
                }

                HttpContext.Session.Set<decimal>("CartTotal", cartTotal);
            }

            return RedirectToAction("Index", "Store", new { categoryID = categoryID });
        }

        [HttpGet]
        [Route("Cart/SelectAddress")]
        public IActionResult SelectAddress()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            int userID = HttpContext.Session.Get<int>("UserID");

            CreditCard card = creditCardService.GetCardByOwner(userID);
            if (card == null)
                return View("ErrorPage", "You need to add a credit card first.");

            List<Address> addresses = addressService.GetByOwner(userID).ToList();
            if (addresses == null || addresses.Count == 0)
                return View("ErrorPage", "You need to add a address first.");

            CardAddressViewModel model = new();
            model.Addresses = CreateAddressList(userID);
            model.MemberID = userID;

            return View("SelectAddress", model);
        }

        [HttpPost]
        [Route("Cart/Pay")]
        public IActionResult Pay(CardAddressViewModel model)
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            int userID = HttpContext.Session.Get<int>("UserID");

            CreditCard card = creditCardService.GetCardByOwner(userID);
            if (card == null)
                return View("ErrorPage", "You need to add a credit card first.");

            List<Address> addresses = addressService.GetByOwner(userID).ToList();
            if (addresses == null || addresses.Count == 0)
                return View("ErrorPage", "You need to add a address first.");

            Address address = addressService.GetByIDByOwner(userID, model.AddressID);

            Order order = new();
            order.MemberID = userID;
            order.AddressID = address.ID;
            order.OrderStatus = "Preparing";

            orderService.Insert(order);

            Order lastOrder = orderService.GetOrdersByUser(userID).OrderByDescending(a => a.ID).FirstOrDefault();

            List<CartItem> cartContents = cartContents = HttpContext.Session.Get<List<CartItem>>("Cart");

            foreach (CartItem item in cartContents)
            {
                OrderDetails od = new();
                od.OrderID = lastOrder.ID;
                od.Price = item.Price;
                od.ProductID = item.ProductID;
                od.Quantity = item.Quantity;

                orderDetailsService.Insert(od);
            }

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("GetOrders", "Order");
        }

        public IActionResult ListCartContents()
        {
            if (!Auth()) return View("ErrorPage", "Err: No Permission");
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("Cart");
            return View("Index", cart);
        }

        List<SelectListItem> CreateAddressList(int userID)
        {
            List<Address> dbAddresses = addressService.GetByOwner(userID).ToList();
            List<SelectListItem> addresses = new();

            foreach (var address in dbAddresses)
            {
                addresses.Add(new SelectListItem() { Value = address.ID.ToString(), Text = address.Name });
            }

            return addresses;
        }
    }
}
