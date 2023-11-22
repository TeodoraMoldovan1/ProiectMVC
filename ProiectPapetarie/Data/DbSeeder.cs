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
            //var userMng = service.GetService<UserManager<IdentityUser>>();
            //var roleMng = service.GetService<RoleManager<IdentityRole>>();

            //// adaugare roluri
            //await roleMng.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            //await roleMng.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //// creare utilizator de tip Admin
            //var admin = new IdentityUser
            //{
            //    UserName = "admin@mail.com",
            //    Email = "admin@mail.com",
            //    EmailConfirmed = true
            //};

            ////verificare daca exista deja un admin user
            //var isUserExist = await userMng.FindByEmailAsync(admin.Email);
            //if (isUserExist is null)
            //{
            //    await userMng.CreateAsync(admin, "123!admin");
            //    await userMng.AddToRoleAsync(admin, Roles.Admin.ToString());
            //}

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

            // Alte operații de seed dacă sunt necesare
            // ...

            // Salvare modificări în baza de date
            // Este important să salvezi modificările în baza de date după efectuarea operațiilor de seed.
            // Aceasta poate varia în funcție de modul în care este configurată aplicația ta.
            // Exemplu: await dbContext.SaveChangesAsync();
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

  
