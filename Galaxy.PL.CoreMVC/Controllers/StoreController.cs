using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic;
using Galaxy.Entities;
using Microsoft.AspNetCore.Mvc;
using Galaxy.PL.CoreMVC.Models.ViewModels.Store;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.PL.CoreMVC.Helpers;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class StoreController : Controller
    {
        ICategoryService categoryService;
        IProductService productService;

        public StoreController(ICategoryService catService, IProductService prodService)
        {
            categoryService = catService;
            productService = prodService;
        }

        [LoggedIn()]
        public IActionResult Index(int? categoryID)
        {
            //Check if logged in.
            if (HttpContext.Session.Get<int>("UserID") == 0)
                return RedirectToAction("Index", "Account");

            StoreMainViewModel model = PreparePage(categoryID);

            return View(model);
        }

        //[Route("/Store/{categoryID:int}/{productID:int}")]


        StoreMainViewModel PreparePage(int? categoryID = null)
        {
            StoreMainViewModel model = new()
            {
                StoreCategoriesViewModel = new(),
                StoreItemsViewModel = new(),
                CartTotal = HttpContext.Session.Get<decimal>("CartTotal")
            };

            foreach (Category cat in categoryService.GetAll())
            {
                model.StoreCategoriesViewModel.Categories.Add(new CategoryViewModel()
                {
                    ID = cat.ID,
                    Name = cat.Name
                });
            }

            ICollection<Product> pulledProducts;
            if (categoryID == null)
                pulledProducts = productService.GetAll().Where(a => a.IsActive).ToList();
            else
                pulledProducts = productService.GetAll().Where(a => a.CategoryID == categoryID && a.IsActive).ToList();

            foreach (Product prod in pulledProducts)
            {
                model.StoreItemsViewModel.Products.Add(new ProductViewModel()
                {
                    ID = prod.ID,
                    CategoryID = prod.CategoryID,
                    Name = prod.Name,
                    Description = prod.Description,
                    ImagePath = prod.ImagePath,
                    FinalPrice = prod.Price //TODO: Fix this!
                });
            }

            return model;
        }
    }
}
