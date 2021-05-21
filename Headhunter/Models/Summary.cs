using System;

namespace Headhunter.Models
{
    // модель соискателя 
    public class Summary
    {
        public int Id { get; set; }
        public string NamePosts { get; set; }
        public DateTime DateOfCreator { get; set; }
    
        //контакты соискателя 
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Telegram { get; set; }
        public string PhoneNumber { get; set; }
        
        //однотипные поля 
        public string NameCompany { get; set; }
        public string YearsOfWork { get; set; }
        public string Position { get; set; }
        public string Duties { get; set; }
        
        //анологичные поля
        public string Education { get; set; }
        public string CoursesTaken { get; set; }

        public bool IsPublic { get; set; }
        public string Description { get; set; }
        public string WorkExperience { get; set; }
        public decimal ExpectedSalary{ get; set; }
        
        
        // user and category
        public int CategoryId { get; set; }
        public   Category Category { get; set; }
        public string UserId { get; set; } 
        public User Employer { get; set; }
    }
}