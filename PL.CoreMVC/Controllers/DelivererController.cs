﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PL.CoreMVC.Controllers
{
    public class DelivererController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
