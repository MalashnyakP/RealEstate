using Estate.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext context { get; set; }

        protected BaseController(ApplicationDbContext _context)
        {
            context = _context;
        }
    }
}