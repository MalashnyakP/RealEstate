using Estate.Data;
using Microsoft.AspNetCore.Mvc;

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