using System.Linq;
using Headhunter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Headhunter.Controllers
{
    public class ValidationController : Controller
    {
        private HeadhunterContext _db;
       

        public ValidationController(HeadhunterContext db)
        {
            _db = db;
            
        }

        public bool CheckLogin(string userName)
        {
         
            return !_db.Users.Any(u => u.UserName == userName);
        }
        
        public bool CheckEmail(string email)
        {
            return !_db.Users.Any(u => u.Email == email);
        }
    }
}