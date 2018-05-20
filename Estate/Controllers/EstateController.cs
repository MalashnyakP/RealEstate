using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estate.Data;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Controllers
{
    public class EstateController : BaseController
    {
        public EstateController(ApplicationDbContext applicationContext) : base(applicationContext) { }

        public IActionResult Details(int Number)
        {
            return View();
        }
    }
}