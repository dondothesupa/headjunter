using System;

namespace Headhunter.Models
{
    // модель ответов отклтков пользователей 
    public class Response
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreator { get; set; }

        public string UserId { get; set; }
        public virtual User Employer { get; set; }

        public int VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }

        public int SummaryId { get; set; }
        public virtual Summary Summary { get; set; }
    }
}