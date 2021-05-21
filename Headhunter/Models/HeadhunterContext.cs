using Headhunter.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Headhunter.Models
{
    public class HeadhunterContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Сategories { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Response>  Responses{ get; set; }
        public DbSet<ChatMessage>  ChatMessages { get; set; }
        
        
        
        public HeadhunterContext(DbContextOptions options) : base(options)
        {
           
        }
    }
}