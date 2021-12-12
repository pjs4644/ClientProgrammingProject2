using Microsoft.AspNetCore.Mvc;
using Project3_Base_Code.Models;
using Project3_Base_Code.Services;
using Project3_Base_Code.ViewModels;

namespace Project3_Base_Code.Controllers
{
    public class DegreesController : Controller
    {
        private readonly IGetDegrees _degreesRepository;

        public DegreesController(IGetDegrees degreesRepository)
        {
            _degreesRepository = facultyRepository;
        }
        public IActionResult Index()
        {
            var allDegrees = _degreesRepository.GetAllDegrees().Result.OrderBy(f => f.degreeName);
            var degreesVM = new DegreesVM()
            {
                degrees = allDegrees.ToList(),
                description = "Degrees"
            };
            return View(degreesVM);
        }
    }
}
