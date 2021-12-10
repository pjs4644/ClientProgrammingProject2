using Microsoft.AspNetCore.Mvc;

namespace Project3_Base_Code.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
