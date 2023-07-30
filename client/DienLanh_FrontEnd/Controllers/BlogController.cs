using Microsoft.AspNetCore.Mvc;

namespace DienLanh_FrontEnd.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
