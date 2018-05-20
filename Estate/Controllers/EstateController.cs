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

        public IActionResult Details(int Id)
        {
            var list = from s in context.Appartments
                       select s;
            list = list.Where(x => x.Id == Id);
            var model = list.ToList()[0];
            return View(model);
        }
    }
}