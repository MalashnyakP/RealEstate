using System.Linq;
using Estate.Data;
using Estate.Models;
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

        public IActionResult Manage()
        {
            var list = from s in context.Appartments
                       select s;

            if (!User.IsInRole("Admin"))
            {
                list = list.Where(x => x.UserEmail == HttpContext.User.Identity.Name);
            }

            AppartmentsListModel model = new AppartmentsListModel(list.ToList());
            return View(model);
        }
    }
}