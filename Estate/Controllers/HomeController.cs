using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Estate.Models;
using Estate.Data;

namespace Estate.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext applicationContext) : base(applicationContext) { }

        public IActionResult Store(string FromPrice, string TopPrice, string SelectedStreet)
        {
            var list = from s in context.Appartments
                       select s;

            if (TopPrice != null || FromPrice != null)
            {
                if (TopPrice == null)
                {
                    list = list.Where(x => x.Price > int.Parse(FromPrice));
                }
                else if (FromPrice == null)
                {
                    list = list.Where(x => x.Price < int.Parse(TopPrice));
                }
                else
                {
                    list = list.Where(x => x.Price > int.Parse(FromPrice) && x.Price < int.Parse(TopPrice));
                }
            }

            if (!String.IsNullOrEmpty(SelectedStreet))
            {
                list = list.Where(x => x.Adress.ToLower().Contains(SelectedStreet.ToLower()));
            }

            AppartmentsListModel model = new AppartmentsListModel(list.ToList());

            return View(model);
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your application description page.";
            var list = (from s in context.Appartments
                        select s).ToList();

            AppartmentsListModel model = new AppartmentsListModel(list);
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
