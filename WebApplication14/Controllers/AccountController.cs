using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;
using WebApplication14.Services;
using WebApplication14.Helpers;
using AutoMapper;
using System;

namespace WebApplication14.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, ApplicationContext context, IMapper mapper,RoleManager<IdentityRole> manager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _roleManager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            if (!_context.Users.Any(m => m.Email == "admin8@gmail.com")){

                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                var userIdentity1 = _mapper.Map<AppUser>(new RegisterModel() { Email = "admin8@gmail.com", First_name = "Vita", Last_name = "Chubenko", Password = "qwerty1234", ConfirmPassword = "qwerty1234", PlaceOfBirth = "Cherkassy", Year = DateTime.Now });
                var result1 = await _userManager.CreateAsync(userIdentity1, "qwerty1234");
                await _userManager.AddToRoleAsync(userIdentity1, "Admin");
                _context.Customers.Add(new Customer { IdentityId = userIdentity1.Id, Location = "Cherkassy" });
                _context.SaveChanges();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Roles.Any(r => r.Name == "Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            var userIdentity = _mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            await  _userManager.AddToRoleAsync(userIdentity, "Customer");

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

          _context.Customers.Add(new Customer { IdentityId = userIdentity.Id, Location = model.PlaceOfBirth });
           _context.SaveChanges();

            return new OkObjectResult("Account created");
        }
    }
}