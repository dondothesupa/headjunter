using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Headhunter.Models;

namespace Headhunter.ViewModels
{
    public class SummaryCreateViewModel
    {
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Название Резюме")]
        public string NamePosts { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамиля")]
        public string SurName { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Укажите ваш Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Укажите ваш Telegram ссылку")]
        public string Telegram { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Укажите ваш телефон номер")]
        public string PhoneNumber { get; set; }
        
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Где до нас работали название компани")]
        public string NameCompany { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Должность ?")]
        public string Position { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Обязанность ? ")]
        public string Duties { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Опыт работы ?")]
        public string YearsOfWork { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Образование ?")]
        public string Education { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Школа курсы ?")]
        public string CousesTaken { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Согласное зарплата")]
        public decimal ExpectedSalary { get; set; }
                
        // добавить Поле хранит все отклики
             
        public List<Category>  Category { get; set; }
        public int CategoryId { get; set; }
        public  int Id{ get; set; }
        public  Category Categ { get; set; }
    }
}