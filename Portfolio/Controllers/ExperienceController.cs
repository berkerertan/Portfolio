﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;
using Portfolio.DAL.Entities;

namespace Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext context = new();
        public IActionResult ExperienceList()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var values = context.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

		[HttpPost]
		public IActionResult CreateExperience(Experience experience)
		{
            context.Experiences.Add(experience);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
		}

	
		public IActionResult DeleteExperience(int id)
		{
            var value = context.Experiences.Find(id);
            context.Experiences.Remove(value);
            context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}

		[HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = context.Experiences.Find(id);
            return View(value);
        }

		[HttpPost]
		public IActionResult UpdateExperience(Experience experience)
		{
			context.Experiences.Update(experience);
			context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}


	}
}
