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



namespace WebApplication14.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, ApplicationContext context, IMapper mapper)
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

            var userIdentity = _mapper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            await  _userManager.AddToRoleAsync(userIdentity, "Customer");

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

          _context.Customers.Add(new Customer { IdentityId = userIdentity.Id, Location = model.PlaceOfBirth });
           _context.SaveChanges();

            return new OkObjectResult("Account created");
        }
    }
}