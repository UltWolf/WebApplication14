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
            

          


        }
    }
    }

 