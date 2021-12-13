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
            _degreesRepository = degreesRepository;
        }
        public IActionResult Index()
        {
            var underDegrees = _degreesRepository.GetUnderDegrees().Result.OrderBy(f => f.degreeName);
            var gradDegrees = _degreesRepository.GetGradDegrees().Result.OrderBy(f => f.degreeName);
            var degreesVM = new DegreesVM()
            {
                underDegrees = underDegrees.ToList(),
                gradDegrees = gradDegrees.ToList(),
                description = "Degrees"
            };
            return View(degreesVM);
        }
    }
}
