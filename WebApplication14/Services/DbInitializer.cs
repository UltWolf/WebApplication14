using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;

namespace WebApplication14.Services
{
    public class DbInitializer
    {
        

        public static  async void Initialize(ApplicationContext _context,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {

            _context.Database.EnsureCreated();

            if (_context.Roles.Any(r => r.Name == "Admin")) return;

            await _roleManager.CreateAsync(new IdentityRole("Admin"));

          
            string user = "admin@gmail.com";
            string password = "qwerty1234";
            await _userManager.CreateAsync(new ApplicationUser() { UserName = user, Email = user, EmailConfirmed = true }, password);
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Admin");

            

        }
    }
}
 