using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities;
using Galaxy.PL.CoreMVC.Helpers;
using Galaxy.PL.CoreMVC.Models.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class CartController : Controller
    {
        IProductService productService;
        ICreditCardService creditCardService;

        public CartController(IProductService prodService, ICreditCardService credService)
        {
            productService = prodService;
            creditCardService = credService;
        }

        public IActionResult Index()
        {
            List<CartItem> cartContents = cartContents = HttpContext.Session.Get<List<CartItem>>("Cart");
            if (cartContents == null)
                cartContents = new();

            return View(cartContents);
        }

        [HttpGet]
        public IActionResult AddToCart(int categoryID, int productID)
        {
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
            else
            {
                //return NotFound("Ürün bulunamadı");
                //return Json("Ürün bulunamadı");

                //TODO: Yeah do sth...
            }

            return RedirectToAction("Index", "Store", new { categoryID = categoryID });
        }

        public IActionResult RemoveFromCart(int productID)
        {
            //TODO: İstenmemiş ama eklenebilir.

            return RedirectToAction("Index");
        }

        public IActionResult Pay()
        {
            int userID = HttpContext.Session.Get<int>("UserID");
            CreditCard card = creditCardService.GetCardByOwner(userID);

            if (card == null)
                return RedirectToAction();

            return RedirectToAction(); //TODO: Redirect to payment page.
        }

        public IActionResult ListCartContents()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("Cart");
            return View("Index", cart);
        }
    }
}
