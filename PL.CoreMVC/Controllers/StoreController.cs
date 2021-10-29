using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using PL.CoreMVC.Models.ViewModels.Store;

namespace PL.CoreMVC.Controllers
{
    public class StoreController : Controller
    {
        IService<Category> categoryService;
        IService<Product> productService;

        public StoreController(IService<Category> catService, IService<Product> prodService)
        {
            categoryService = catService;
            productService = prodService;
        }

        public IActionResult Index()
        {
            StoreMainViewModel model = new()
            {
                StoreCategoriesViewModel = new(),
                StoreItemsViewModel = new()
            };

            foreach (Category cat in categoryService.GetAll())
            {
                model.StoreCategoriesViewModel.Categories.Add(new CategoryViewModel()
                {
                    ID = cat.CategoryID,
                    Name = cat.Name
                });
            }

            foreach (Product prod in productService.GetAll())
            {
                model.StoreItemsViewModel.Products.Add(new ProductViewModel()
                {
                    ID = prod.ProductID,
                    Name = prod.Name,
                    Description=prod.Description,
                    Image =prod.Image,
                    FinalPrice =prod.Price //TODO: Fix this!
                });
            }

            return View(model);
        }
    }
}
