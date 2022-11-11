using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using projektas.Auth.Model;

namespace projektas.Data
{
    public class AuthDbSeeder
    {
        private readonly UserManager<ForumRestUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthDbSeeder(UserManager<ForumRestUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }
        private async Task AddDefaultRoles()
        {
            foreach (var role in ForumRoles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private async Task AddAdminUser()
        {
            var newAdminUser = new ForumRestUser()
            {
                UserName = "admin",
                Email = "admin@kolekcionierius.lt"
            };
            var adminExist = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if(adminExist == null)
            {
                var createAdminUser = await _userManager.CreateAsync(newAdminUser, "Slaptazodis1.");
                if(createAdminUser.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, ForumRoles.All);
                }
            }

        }

    }
}
