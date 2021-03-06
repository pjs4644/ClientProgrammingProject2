using Microsoft.AspNetCore.Mvc;
using Project3_Base_Code.Models;
using Project3_Base_Code.Services;
using Project3_Base_Code.ViewModels;

namespace Project3_Base_Code.Controllers
{
    public class MinorsController : Controller
    {
        private readonly IGetMinors _minorsRepository;

        public MinorsController(IGetMinors minorsRepository)
        {
            _minorsRepository = minorsRepository;
        }
        public IActionResult Index()
        {
            var allMinors = _minorsRepository.GetAllMinor().Result.OrderBy(f => f.title);
            var minorsVM = new MinorsVM()
            {
                Minors = allMinors.ToList(),
                Title = "Available Minors"
            };
            return View(minorsVM);
        }
    }
}
