using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models
{
    public class SeedUserAdmin
    {
        private const string adminUser = "admin@dotnet-pizza.fr";
        private const string adminPassword = "Secret123!";
        public static async Task EnsurePopulatedUserAdmin(IApplicationBuilder app)
        {
           
            UserManager<ApplicationUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            //Error DI On userManager See => program class add UseDefautlService

            ApplicationUser user = await userManager.FindByEmailAsync("admin@dotnet-pizza.fr");

            if (user == null)
            {
                user = new ApplicationUser() { UserName = adminUser, Email = adminUser };
                await userManager.CreateAsync(user, adminPassword);
                IdentityRole role = await roleManager.FindByNameAsync("Administrator");
                await userManager.AddToRoleAsync(user, role.Name);
            }
        }

        public static async Task EnsurePopulatedRoles(IApplicationBuilder app)
        {
            List<string> roles = new List<string>
            {
                "Administrator","Client"
            };
           
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            //Error DI On userManager See => program class add UseDefautlService


            foreach (var item in roles)
            {
                IdentityRole role = await roleManager.FindByNameAsync(item);

                if (role == null)
                {
                    role = new IdentityRole() { Name = item };
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
