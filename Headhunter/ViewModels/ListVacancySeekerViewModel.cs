using System.Collections.Generic;
using Forum.ViewModel;
using Headhunter.Models;

namespace Headhunter.ViewModels
{
    public class ListVacancySeekerViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public List<Category> Categories { get; set; }
        public List<Summary> Summaries { get; set; }
        public Response Response { get; set; }
    }
}