using System.Linq;
using Headhunter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Headhunter.Controllers
{
    public class СategoriesController : Controller
    {
        private HeadhunterContext _db;

        public СategoriesController(HeadhunterContext db)
        {
            _db = db;
            if (!_db.Сategories.Any())
            {
                _db.Сategories.Add(new Category() {Id = 1, Name = "административный персонал"});
                _db.Сategories.Add(new Category() {Id = 2, Name = "руководитель"});
                _db.Сategories.Add(new Category() {Id = 3, Name = "без опыта"});
                _db.Сategories.Add(new Category() {Id = 4, Name = "производство"});
                _db.Сategories.Add(new Category() {Id = 5, Name = "торговля"});
                _db.SaveChangesAsync();
            }
        }
    }
}