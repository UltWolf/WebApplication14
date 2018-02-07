using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;
using WebApplication14.Services;
using Microsoft.Azure.KeyVault.Models;
using WebApplication14.Auth;
using Newtonsoft.Json;
using System.Net;
using WebApplication14.Helpers;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebApplication14.Controllers
{
    [Route("api/Auth")]
    public class AuthController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly RoleManager<IdentityRole>_roleManager;
        public AuthController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
    
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = await GetClaimsIdentity(model.Email, model.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }
            var userToVerify = await _userManager.FindByNameAsync(model.Email);
            List<string> ListRoles = new List<string>(await _userManager.GetRolesAsync(userToVerify));
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await _jwtFactory.GenerateEncodedToken(model.Email, identity,ListRoles),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
           
                var userToVerify = await _userManager.FindByNameAsync(userName);
                List<string> ListRoles = new List<string>(await _userManager.GetRolesAsync(userToVerify));
            if (userToVerify != null)
                {
                    if (await _userManager.CheckPasswordAsync(userToVerify, password))
                    {
                    return _jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id,ListRoles);  
                    }
                }
            
            return null;
        }
    }
}
