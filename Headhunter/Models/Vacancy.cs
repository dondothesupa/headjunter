using System;
using System.ComponentModel.DataAnnotations;

namespace Headhunter.Models
{
    // модель ваканци 
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreator { get; set; }
        public bool IsPublic { get; set; }
        public string Description { get; set; }
        public string WorkExperience{ get; set; }
        public decimal Salary{ get; set; }

        public int CategoryId { get; set; }
        public   Category Category { get; set; }
        public string UserId { get; set; } 
        public User Employer{ get; set; }
        
    }
}