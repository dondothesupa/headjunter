using System;
using System.Collections.Generic;
using System.Linq;
using Headhunter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Headhunter.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private HeadhunterContext _db;

        public ResponsesController(UserManager<User> userManager, SignInManager<User> signInManager,
            HeadhunterContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index(int id)
        {
            List<Response> responses = _db.Responses.Where(r => r.VacancyId == id).ToList();
            foreach (var response in responses)
            {
                response.Employer = _db.Users.FirstOrDefault(u => u.Id == response.UserId);
                response.Summary = _db.Summaries.FirstOrDefault(s => s.Id == response.SummaryId);
                response.Vacancy = _db.Vacancies.FirstOrDefault(s => s.Id == response.VacancyId);
            }

            return View(responses);
        }

        // POST
        [HttpPost]
        [Authorize(Roles = "seeker")]
        public IActionResult Create(string desc, int sumId, int vacId)
        {
            if (desc != null && sumId != null && vacId != null)
            {
                string userId = _userManager.GetUserId(User);
                Response res = new Response
                {
                    DateOfCreator = DateTime.Now,
                    Description = desc,
                    UserId = userId,
                    SummaryId = sumId,
                    VacancyId = vacId
                };
                _db.Entry(res).State = EntityState.Added;
                _db.SaveChanges();
                return RedirectToAction("ListVacancySeeker", "Vacancies");
            }

            return NoContent();
        }
    }
}