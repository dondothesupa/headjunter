using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Headhunter.Models;
using Headhunter.Service;
using Headhunter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Headhunter.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHostEnvironment _environment;
        private readonly FileUploadService _fileUploadService;
        private HeadhunterContext _db;

        public UsersController(UserManager<User> userManager,
            SignInManager<User> signInManager, IHostEnvironment environment,
            FileUploadService fileUploadService, HeadhunterContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
            _fileUploadService = fileUploadService;
            _db = db;
        }

        [Authorize]
        // GET
        public IActionResult Index(string? userId)
        {
            if (userId == null)
            {
                userId = _userManager.GetUserId(User);
            }

            User user = _db.Users.FirstOrDefault(u => u.Id == userId);
            var roles = _userManager.GetRolesAsync(user);

            return View(user);
        }

        // GET
        public IActionResult Delete(string userId)
        {
            User user = _db.Users.FirstOrDefault(u => u.Id == userId);
            _signInManager.SignOutAsync();
            _db.Entry(user).State = EntityState.Deleted;
            _db.SaveChanges();


            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public IActionResult Edit(string id = null)
        {
            User user = null;
            user = id == null ? _userManager.GetUserAsync(User).Result : _userManager.FindByIdAsync(id).Result;
            UserEditViewModel model = new UserEditViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                PhotoPath = user.AvatarPath
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.PhoneNumber = model.PhoneNumber;
                    user.UserName = model.UserName;
                    user.Email = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult ChatMessage(string id)
        {
            User user = _db.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Message(string userId, string message)
        {
            if (userId != null && message != null)
            {
                ChatMessage messages = new ChatMessage
                {
                    UserId = userId,
                    Message = message
                };
                
                var result = _db.ChatMessages.AddAsync(messages);
                if (result.IsCompletedSuccessfully)
                    await _db.SaveChangesAsync();
            }
            
            string data = "";
            List<ChatMessage> chatMessages = _db.ChatMessages.ToList();
            if (chatMessages.Count > 100)
                chatMessages.RemoveRange(0, 95);
            foreach (var msg in chatMessages)
            {
             
                    data +=
                        $"<div style='margin-right: -80%; display: block; margin-top : 5px; margin-bottom:5px;'><img style='width: 50px; height: 50px; margin-right: -120px;' src='/{msg.User.AvatarPath}'>\n<p style='margin-top: -30px; display : block'>{msg.User.Email}\n<p style='font-size: 10px; margin-right: -40px; margin-top: -50px;'>{msg.CreatedAt.ToShortTimeString()}<p style='font-size: 19px; margin-top: 30px; display: block;' >{msg.Message}</p></div>";
                
                    data +=
                        $"<div style='margin-left: -80%; display: block; margin-top : 5px; margin-bottom:5px;'><img style='width: 50px; height: 50px; margin-left: -120px;' src='/{msg.User.AvatarPath}'>\n<p style='margin-top: -30px; display : block'>{msg.User.Email}\n <p style='font-size: 10px;margin-left: -40px;margin-top: -50px;'>{msg.CreatedAt.ToShortTimeString()}<p style='font-size: 19px; margin-top: 30px; display: block;' >{msg.Message}</p></div>";
            }
            return Json(data);
        }
    }s
}