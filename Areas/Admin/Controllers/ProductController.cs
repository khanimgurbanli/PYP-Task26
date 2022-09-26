using Microsoft.AspNetCore.Mvc;

namespace IntegratedTemplateMVCProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Area("product")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
