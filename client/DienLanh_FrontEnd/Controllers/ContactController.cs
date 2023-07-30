using DienLanh_FrontEnd.Common;
using Microsoft.AspNetCore.Mvc;

namespace DienLanh_FrontEnd.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.serverAPI = ApiURL.serverAPI;
            return View();
        }
    }
}
