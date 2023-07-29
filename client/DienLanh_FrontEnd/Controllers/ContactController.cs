using DienLanh_FrontEnd.Common;
using DienLanh_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace DienLanh_FrontEnd.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.serverAPI = ApiURL.serverAPI;
            ViewBag.Breadcrumb = new List<Breadcrumb> {
                        new Breadcrumb{ title="Trang chủ",link="/Home/Index", active= false },
                        new Breadcrumb{ title="Liên hệ",link="/Contact/Index", active= true},
                    };
            return View();
        }
    }
}
