using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.Entities;
using Galaxy.Entities.Location;
using Galaxy.PL.CoreMVC.Models.ViewModels.Admin;
using Galaxy.PL.CoreMVC.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Galaxy.PL.CoreMVC.Controllers
{
    public class AdminController : Controller
    {
        ICategoryService categoryService;
        IProductService productService;
        IUserService userService;

        public AdminController(ICategoryService catService, IProductService prodService, IUserService usrService)
        {
            categoryService = catService;
            productService = prodService;
            userService = usrService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Admin/AddCategory")]
        public IActionResult AddCategory()
        {
            AdminCategoryViewModel model = new();

            return View("AdminAddCategory", model);
        }

        [HttpPost]
        [Route("Admin/AddCategory")]
        public IActionResult AddCategory(AdminCategoryViewModel model)
        {
            Category category = new();
            category.Name = model.Name;
            category.IsActive = model.IsActive;

            if (categoryService.Insert(category) > 0)
                TempData["Message"] = "Success";

            return View("AdminAddCategory", model);
        }

        [HttpPost]
        [Route("Admin/UpdateCategories")]
        public IActionResult UpdateCategories(List<AdminCategoryViewModel> model)
        {
            foreach (var cat in model)
            {
                Category young = CreateCategoryFromModel(cat);
                Category old = categoryService.GetByID(cat.CategoryID);
                categoryService.Update(old, young);
            }

            return RedirectToAction("ListCategories");
        }

        [HttpGet]
        [Route("Admin/DeleteCategory")]
        public IActionResult DeleteCategory(int categoryID)
{
            Category old = categoryService.GetByID(categoryID);
            Category young = categoryService.GetByID(categoryID);
            young.IsActive = false;

            categoryService.Update(old, young);

            return RedirectToAction("ListCategories");
        }

        [HttpGet]
        [Route("Admin/ListCategories")]
        public IActionResult ListCategories()
        {
            List<AdminCategoryViewModel> model = new();
            List<Category> dbCategories = categoryService.GetAll().Where(a => a.IsActive).ToList();

            foreach (Category category in dbCategories)
            {
                model.Add(CreateModelFromCategory(category));
            }

            return View("AdminCategoryList", model);
        }

        [HttpGet]
        [Route("Admin/AddProduct")]
        public IActionResult AddProduct()
        {
            AdminProductViewModel model = new();

            return View("AdminAddProduct", model);
        }

        [HttpPost]
        [Route("Admin/AddProduct")]
        public IActionResult AddProduct(AdminProductViewModel model)
        {
            Product product = CreateProductFromModel(model);

            if (productService.Insert(product) > 0)
                TempData["Message"] = "Success";

            return View("AdminAddProduct", model);
        }

        [HttpPost]
        [Route("Admin/UpdateProducts")]
        public IActionResult UpdateProducts(List<AdminProductViewModel> model)
        {
            foreach (var prod in model)
            {
                Product young = CreateProductFromModel(prod);
                Product old = productService.GetByID(prod.ProductID);
                productService.Update(old, young);
            }

            return RedirectToAction("ListProducts");
        }

        [HttpGet]
        [Route("Admin/DeleteProduct")]
        public IActionResult DeleteProduct(int productID)
        {
            Product old = productService.GetByID(productID);
            Product young = productService.GetByID(productID);
            young.IsActive = false;

            productService.Update(old, young);

            return RedirectToAction("ListProducts");
        }

        [HttpGet]
        [Route("Admin/ListProducts")]
        public IActionResult ListProducts()
        {
            List<AdminProductViewModel> model = new();
            List<Product> dbproducts = productService.GetAll().Where(a => a.IsActive).ToList();

            foreach (Product product in dbproducts)
            {
                model.Add(CreateModelFromProduct(product));
            }

            return View("AdminProductList", model);
        }

        [HttpGet]
        [Route("Admin/AddEmployee")]
        public IActionResult AddEmployee()
        {
            AdminEmployeeViewModel model = new();

            return View("AdminAddEmployee", model);
        }

        [HttpPost]
        [Route("Admin/AddEmployee")]
        public IActionResult AddEmployee(AdminEmployeeViewModel model)
        {
            User user = CreateUserFromModel(model);

            if (userService.Insert(user) > 0)
                TempData["Message"] = "Success";
            else
                TempData["Message"] = "Fail.";

            return View("AdminAddEmployee", model);
        }

        [HttpPost]
        [Route("Admin/UpdateEmployees")]
        public IActionResult UpdateEmployees(List<AdminEmployeeViewModel> model)
        {
            foreach (var user in model)
            {
                User young = CreateUserFromModel(user);
                User old = userService.GetByID(user.EmployeeID);
                userService.Update(old, young);
            }

            return RedirectToAction("ListEmployees");
        }

        [HttpGet]
        [Route("Admin/DeleteEmployee")]
        public IActionResult DeleteEmployee(int employeeID)
        {
            User old = userService.GetByID(employeeID);
            User young = userService.GetByID(employeeID);
            young.IsActive = false;

            userService.Update(old, young);

            return RedirectToAction("ListEmployees");
        }

        [HttpGet]
        [Route("Admin/ListEmployees")]
        public IActionResult ListEmployees()
        {
            List<AdminEmployeeViewModel> model = new();
            List<User> dbUsers = userService.GetAll().Where(a => a.IsActive && a.UserType != 0).ToList();

            foreach (User user in dbUsers)
            {
                model.Add(CreateModelFromUser(user));
            }

            return View("AdminEmployeeList", model);
        }



        Category CreateCategoryFromModel(AdminCategoryViewModel model)
        {
            return new Category()
            {
                ID = model.CategoryID,
                Name = model.Name,
                IsActive = model.IsActive
            };
        }

        AdminCategoryViewModel CreateModelFromCategory(Category category)
        {
            return new AdminCategoryViewModel()
            {
                CategoryID = category.ID,
                IsActive = category.IsActive,
                Name = category.Name
            };
        }

        Product CreateProductFromModel(AdminProductViewModel model)
        {
            return new Product()
            {
                ID = model.ProductID,
                CategoryID = model.CategoryID,
                Name = model.Name,
                IsActive = model.IsActive,
                Description = model.Description,
                DiscountedPrice = model.DiscountedPrice,
                ImagePath = model.ImagePath,
                Price = model.Price
            };
        }

        AdminProductViewModel CreateModelFromProduct(Product p)
        {
            return new AdminProductViewModel()
            {
                Price = p.Price,
                ImagePath = p.ImagePath,
                DiscountedPrice = p.DiscountedPrice,
                Description = p.Description,
                IsActive = p.IsActive,
                Name = p.Name,
                CategoryID = p.CategoryID,
                ProductID = p.ID
            };
        }

        User CreateUserFromModel(AdminEmployeeViewModel model)
        {
            return new User()
            {
                ID = model.EmployeeID,
                UserType = model.UserType,
                BirthDate = model.BirthDate,
                IsMailVerified = true,
                IsPasswordValid = false,
                Mail = model.Mail,
                Name = model.Name,
                Password = model.Password,
                Phone = model.Phone,
                Surname = model.Surname,
                IsActive = true
            };
        }

        AdminEmployeeViewModel CreateModelFromUser(User user)
        {
            return new AdminEmployeeViewModel()
            {
                Surname = user.Surname,
                Phone = user.Phone,
                Password = user.Password,
                Name = user.Name,
                Mail = user.Mail,
                IsPasswordValid = user.IsPasswordValid,
                BirthDate = user.BirthDate,
                EmployeeID = user.ID,
                IsMailVerified = user.IsMailVerified,
                UserType = user.UserType,
                IsActive = user.IsActive
            };
        }
    }
}