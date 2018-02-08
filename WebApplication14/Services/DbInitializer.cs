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
    public class DbInitializer:IDbInitializer
    {

        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public DbInitializer(
            ApplicationContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async void Initialize()
        {
            _context.Database.EnsureCreated();

            if (_context.Roles.Any(r => r.Name == "Admin")) return;

            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            var userIdentity = _mapper.Map<AppUser>(new RegisterModel() { Email = "admin5@gmail.com", First_name = "Vita", Last_name = "Chubenko", Password = "qwerty1234", ConfirmPassword = "qwerty1234", PlaceOfBirth = "Cherkassy" ,Year = DateTime.Now});
            var result = await _userManager.CreateAsync(userIdentity, "qwerty1234");
            await _userManager.AddToRoleAsync(userIdentity, "Admin");
            _context.Customers.Add(new Customer { IdentityId = userIdentity.Id, Location = "Cherkassy" });
            _context.SaveChanges();
        }
    }
    }

 