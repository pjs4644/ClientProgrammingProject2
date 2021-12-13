using Microsoft.AspNetCore.Mvc;
using Project3_Base_Code.Models;
using Project3_Base_Code.Services;
using Project3_Base_Code.ViewModels;

namespace Project3_Base_Code.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IGetFaculty _facultyRepository;

        public FacultyController(IGetFaculty facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }
        public IActionResult Index()
        {
            var allFaculty = _facultyRepository.GetAllFaculty().Result.OrderBy(f => f.username);
            var facultyVM = new FacultyVM()
            {
                Faculty = allFaculty.ToList(),
                Title = "Faculty"
            };
            return View(facultyVM);
        }
    }
}
