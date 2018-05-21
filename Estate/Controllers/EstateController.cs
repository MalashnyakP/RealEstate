using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Estate.Data;
using Estate.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var appartment = context.Appartments.Find(id);

            if (!System.IO.File.Exists("wwwroot\\images\\" + appartment.Images))
            {
                return RedirectToAction("Manage");
            }

            System.IO.File.Delete("wwwroot\\images\\" + appartment.Images);

            context.Appartments.Remove(context.Appartments.Find(id));
            context.SaveChanges();
            return RedirectToAction("Manage");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Submit(IFormFile file, string addres, int price, string description)
        {
            if (!file.ContentType.Contains("image"))
            {
                return View("Add");
            }

            var fileName = "wwwroot\\images\\"
                + file.FileName.Split(new char[] { '\\' }).Last();

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            fileName = fileName.Split(new char[] { '\\' }).Last();
            Appartment add = new Appartment(0, addres, price,
                fileName, HttpContext.User.Identity.Name,
                description);
            context.Appartments.Add(add);
            context.SaveChanges();

            return RedirectToAction("Add");
        }
    }
}