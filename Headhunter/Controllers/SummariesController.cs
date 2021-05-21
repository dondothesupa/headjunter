using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Headhunter.Models;
using Headhunter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Headhunter.Controllers
{
    public class SummariesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private HeadhunterContext _db;

        public SummariesController(UserManager<User> userManager, SignInManager<User> signInManager,
            HeadhunterContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            СategoriesController controller = new СategoriesController(_db);
        }

        [Authorize]
        // GET
        public IActionResult Index(int id)
        {
            Summary summary = _db.Summaries.FirstOrDefault(s => s.Id == id);
            summary.Employer = _db.Users.FirstOrDefault(u => u.Id == summary.UserId);
            summary.Category = _db.Сategories.FirstOrDefault(c => c.Id == summary.CategoryId);

            return View(summary);
        }

        [Authorize(Roles = "seeker")]
        [HttpGet]
        public IActionResult Create()
        {
            SummaryCreateViewModel model = new SummaryCreateViewModel();
            model.Category = _db.Сategories.ToList();
            return View(model);
        }

        [Authorize(Roles = "seeker")]
        [HttpPost]
        public IActionResult Create(SummaryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UserId = _userManager.GetUserId(User);
                Summary summary = new Summary
                {
                    DateOfCreator = DateTime.Now,
                    UserId = UserId,
                    IsPublic = true,
                    NamePosts = model.NamePosts,
                    Name = model.Name,
                    SurName = model.SurName,
                    Email = model.Email,
                    Telegram = model.Telegram,
                    PhoneNumber = model.PhoneNumber,
                    NameCompany = model.NameCompany,
                    YearsOfWork = model.YearsOfWork,
                    Position = model.Position,
                    Duties = model.Duties,
                    Education = model.Education,
                    CoursesTaken = model.CousesTaken,
                    ExpectedSalary = model.ExpectedSalary,
                    CategoryId = model.CategoryId
                };

                _db.Entry(summary).State = EntityState.Added;
                _db.SaveChanges();
                return RedirectToAction("Index", "Users");
            }

            return View();
        }

        public IActionResult ListSummary()
        {
            string userId = _userManager.GetUserId(User);
            List<Summary> summaries = _db.Summaries.Where(v => v.UserId == userId).ToList();

            return View(summaries);
        }

        [Authorize(Roles = "seeker")]
        public IActionResult Edit(int id)
        {
            Summary summary = _db.Summaries.FirstOrDefault(s => s.Id == id);
            // summary.Employer = _db.Users.FirstOrDefault(u => u.Id == vacancy.UserId);
            summary.Category = _db.Сategories.FirstOrDefault(c => c.Id == summary.CategoryId);
            if (summary != null)
            {
                SummaryCreateViewModel model = new SummaryCreateViewModel
                {
                    NamePosts = summary.NamePosts,
                    Name = summary.Name,
                    SurName = summary.SurName,
                    Email = summary.Email,
                    Telegram = summary.Telegram,
                    PhoneNumber = summary.PhoneNumber,
                    NameCompany = summary.NameCompany,
                    YearsOfWork = summary.YearsOfWork,
                    Position = summary.Position,
                    Duties = summary.Duties,
                    Education = summary.Education,
                    CousesTaken = summary.CoursesTaken,
                    ExpectedSalary = summary.ExpectedSalary,
                    Id = summary.Id,
                    Categ = summary.Category
                };
                model.Category = _db.Сategories.ToList();

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "seeker")]
        public async Task<IActionResult> Edit(SummaryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Summary summary = _db.Summaries.FirstOrDefault(s => s.Id == model.Id);
                if (summary != null)
                {
                    summary.CategoryId = model.CategoryId;
                    summary.NamePosts = model.NamePosts;
                    summary.Name = model.Name;
                    summary.SurName = model.SurName;
                    summary.Email = model.Email;
                    summary.Telegram = model.Telegram;
                    summary.PhoneNumber = model.PhoneNumber;
                    summary.NameCompany = model.NameCompany;
                    summary.YearsOfWork = model.YearsOfWork;
                    summary.Position = model.Position;
                    summary.Duties = model.Duties;
                    summary.Education = model.Education;
                    summary.CoursesTaken = model.CousesTaken;
                    summary.ExpectedSalary = model.ExpectedSalary;
                    summary.DateOfCreator = DateTime.Now;
                    summary.CategoryId = model.CategoryId;
                    _db.Entry(summary).State = EntityState.Modified;
                }

                _db.SaveChanges();
            }

            return RedirectToAction("ListSummary", "Summaries");
        }

        [Authorize(Roles = "seeker")]
        public IActionResult UpDate(int id)
        {
            Summary summary = _db.Summaries.FirstOrDefault(s => s.Id == id);
            summary.DateOfCreator = DateTime.Now;
            _db.Entry(summary).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ListSummary", "Summaries");
        }

        [Authorize(Roles = "seeker")]
        public IActionResult Publish(int id)
        {
            Summary summary = _db.Summaries.FirstOrDefault(s => s.Id == id);
            if (summary != null && summary.IsPublic)
                summary.IsPublic = false;
            else
                summary.IsPublic = true;

            _db.Entry(summary).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ListSummary", "Summaries");
        }
    }
}