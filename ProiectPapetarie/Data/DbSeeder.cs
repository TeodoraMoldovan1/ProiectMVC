using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProiectPapetarie.Constants;
using System;

namespace ProiectPapetarie.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultDataAsync(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            // Adaugare roluri
            await EnsureRoleExists(roleManager, Roles.Admin.ToString());
            await EnsureRoleExists(roleManager, Roles.User.ToString());

            // Creare utilizator de tip Admin
            var adminEmail = "admin@mail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "ParolaTa123!");

                // Adaugare utilizator la rol
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
            }
        }

        private static async Task EnsureRoleExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}

  
