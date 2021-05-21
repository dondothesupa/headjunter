using System.Threading.Tasks;
using Headhunter.Models;
using Microsoft.AspNetCore.Identity;

namespace Headhunter.Service
{
    public class RoleInitializer 
    {
        public static async Task Initialize(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            var roles = new[] {"employer", "seeker"};

            foreach (var role in roles)
            {
                if (await roleManager.FindByNameAsync(role) is null)
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}