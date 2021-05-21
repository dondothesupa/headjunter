using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.ViewModel;
using Headhunter.Models;
using Headhunter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Headhunter.Controllers
{
    public enum SortState
    { 
        SalaryAsc,
        SalaryDesc
    }

    public class VacanciesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private HeadhunterContext _db;

        public VacanciesController(UserManager<User> userManager, SignInManager<User> signInManager,
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
            Vacancy vacancy = _db.Vacancies.FirstOrDefault(v => v.Id == id);
            vacancy.Employer = _db.Users.FirstOrDefault(u => u.Id == vacancy.UserId);
            vacancy.Category = _db.Сategories.FirstOrDefault(c => c.Id == vacancy.CategoryId);

            return View(vacancy);
        }

        [Authorize(Roles = "employer")]
        [HttpGet]
        public IActionResult Create()
        {
            VacancyCreateViewModel model = new VacancyCreateViewModel();
            model.Category = _db.Сategories.ToList();
            return View(model);
        }

        [Authorize(Roles = "employer")]
        [HttpPost]
        public IActionResult Create(VacancyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UserId = _userManager.GetUserId(User);
                Vacancy vacancy = new Vacancy
                {
                    DateOfCreator = DateTime.Now,
                    UserId = UserId,
                    IsPublic = true,
                    Description = model.Description,
                    Name = model.Name,
                    WorkExperience = model.WorkExperience,
                    Salary = model.Salary,
                    CategoryId = model.CategoryId
                };

                _db.Entry(vacancy).State = EntityState.Added;
                _db.SaveChanges();
                return RedirectToAction("Index", "Users");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "employer")]
        public IActionResult ListVacancy()
        {
            string userId = _userManager.GetUserId(User);
            List<Vacancy> vacancies = _db.Vacancies.Where(v => v.UserId == userId).ToList();

            return View(vacancies);
        }

        [Authorize(Roles = "employer")]
        public IActionResult UpDate(int id)
        {
            Vacancy vacancy = _db.Vacancies.FirstOrDefault(v => v.Id == id);
            vacancy.DateOfCreator = DateTime.Now;
            _db.Entry(vacancy).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ListVacancy", "Vacancies");
        }

        [Authorize(Roles = "employer")]
        public IActionResult Publish(int id)
        {
            Vacancy vacancy = _db.Vacancies.FirstOrDefault(v => v.Id == id);
            if (vacancy.IsPublic)
            {
                vacancy.IsPublic = false;
            }
            else
            {
                vacancy.IsPublic = true;
            }

            _db.Entry(vacancy).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ListVacancy", "Vacancies");
        }

        [Authorize(Roles = "employer")]
        public IActionResult Edit(int id)
        {
            Vacancy vacancy = _db.Vacancies.FirstOrDefault(v => v.Id == id);
            vacancy.Category = _db.Сategories.FirstOrDefault(c => c.Id == vacancy.CategoryId);
            if (vacancy != null)
            {
                VacancyCreateViewModel model = new VacancyCreateViewModel
                {
                    Name = vacancy.Name,
                    Description = vacancy.Description,
                    WorkExperience = vacancy.WorkExperience,
                    Salary = vacancy.Salary,
                    Id = vacancy.Id,
                    Categ = vacancy.Category
                };
                model.Category = _db.Сategories.ToList();


                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "employer")]
        public async Task<IActionResult> Edit(VacancyCreateViewModel model)
        {
            Vacancy vacancy = _db.Vacancies.FirstOrDefault(v => v.Id == model.Id);
            vacancy.CategoryId = model.CategoryId;
            vacancy.Name = model.Name;
            vacancy.Description = model.Description;
            vacancy.WorkExperience = model.WorkExperience;
            vacancy.DateOfCreator = DateTime.Now;
            vacancy.CategoryId = model.CategoryId;
            _db.Entry(vacancy).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ListVacancy", "Vacancies");
        }

        [HttpGet]
        [Authorize(Roles = "seeker")]
        public IActionResult ListVacancySeeker(string? name, int? CatId, int page = 1,
            SortState sortOrder = SortState.SalaryAsc)
        {
            List<Vacancy> vacancies = new List<Vacancy>();

            if (CatId != null)
            {
                vacancies = _db.Vacancies.Where(v => v.IsPublic == true).Where(v => v.CategoryId == CatId)
                    .OrderBy(v => v.DateOfCreator)
                    .ToList();
            }
            else
            {
                vacancies = _db.Vacancies.Where(v => v.IsPublic == true)
                    .OrderBy(v => v.DateOfCreator)
                    .ToList();
            }

            if (name != null)
            {
                name = Strings.Trim(name);
                vacancies = vacancies.Where(v => v.Name == name).ToList();
            }

            foreach (var vac in vacancies)
            {
                vac.Category = _db.Сategories.FirstOrDefault(c => c.Id == vac.CategoryId);
                vac.Employer = _db.Users.FirstOrDefault(u => u.Id == vac.UserId);
            }

            ViewBag.SalarySort = sortOrder == SortState.SalaryAsc ? SortState.SalaryDesc : SortState.SalaryAsc;
            switch (sortOrder)
            {
                case SortState.SalaryDesc:
                    vacancies = vacancies.OrderByDescending(s => s.Salary).ToList();
                    break;
                case SortState.SalaryAsc:
                    vacancies = vacancies.OrderBy(s => s.Salary).ToList();
                    break;
            }

            string userId = _userManager.GetUserId(User);
            int pageSize = 20;
            var count = vacancies.Count();
            var items = vacancies.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ListVacancySeekerViewModel listVacancySeekerViewModel = new ListVacancySeekerViewModel
            {
                PageViewModel = pageViewModel,
                Vacancies = items,
                Categories = _db.Сategories.ToList(),
                Summaries = _db.Summaries.Where(s => s.UserId == userId).ToList(),
                Response = new Response()
            };

            return View(listVacancySeekerViewModel);
        }
    }
}