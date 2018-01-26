﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;
using WebApplication14.Services;
using WebApplication14.Helpers;
using AutoMapper;



namespace WebApplication14.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;



        public AccountController(UserManager<AppUser> userManager, ApplicationContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _context.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.PlaceOfBirth });
            await _context.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }



    }
}