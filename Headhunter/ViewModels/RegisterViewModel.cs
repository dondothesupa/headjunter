using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Headhunter.ViewModels
{
   
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Логин")]
        [Remote(action: "CheckLogin", controller: "Validation", ErrorMessage = "Ранее использован : ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Remote(action: "CheckEmail", controller: "Validation", ErrorMessage = "Ранее использован :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефонный номер")]
        
        public string PhoneNumber { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Аватар")]
        public IFormFile FormFile { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        public string Role { get; set; } 

        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это обязательное поле :")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}