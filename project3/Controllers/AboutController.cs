﻿
using Microsoft.AspNetCore.Mvc;
using Project3_Base_Code.Models;
using Project3_Base_Code.Services;
using Project3_Base_Code.ViewModels;

namespace Project3_Base_Code.Controllers
{
    public class AboutController : Controller
    {
        private readonly IGetAbout _aboutRepository;

        public AboutController(IGetAbout aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public IActionResult Index()
        {
            var allAbout = _aboutRepository.GetAllAbout().Result.OrderBy(f => f.title);
            var aboutVM = new AboutVM()
            {
                About = allAbout.ToList(),
                Title = "This is your Faculty"
            };
            return View(aboutVM);
        }
    }
}
