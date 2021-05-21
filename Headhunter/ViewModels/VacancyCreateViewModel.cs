using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Headhunter.Models;

namespace Headhunter.ViewModels
{
    public class VacancyCreateViewModel
    {
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Название вакансии")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Описание вакансии")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Указание требуемого опыта работы от и до")]
        public string WorkExperience{ get; set; }
        [Required(ErrorMessage = "Это обязательное поле :")]
        [DataType(DataType.Text)]
        [Display(Name = "Предлагаемая зарплата")]
        public decimal Salary{ get; set; }

        public List<Category>  Category { get; set; }
        public int CategoryId { get; set; }
        public  int Id{ get; set; }
        public  Category Categ { get; set; }
    }
}