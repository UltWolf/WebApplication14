using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;

namespace WebApplication14.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
       
        public SearchController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpPost]
        public IEnumerable<Product> SearchByCategories([FromBody] SearchModel searchModel)
        {
            var products = _context.Products.ToAsyncEnumerable();
            if (searchModel.Category != null)
            {
                products = products.Where(m => m.Category == searchModel.Category);
            }
            if (searchModel.Name != null)
            {
                products = products.Where(m => m.Name.ToUpper() == searchModel.Name.ToUpper());
            }
            if (searchModel.Country != null)
            {
                products = products.Where(m => m.Country == searchModel.Country);
            }
            if (searchModel.Price != null)
            {
                if (searchModel.MinPrice != null)
                {
                    products = products.Where(m => m.Price > searchModel.MinPrice && m.Price < searchModel.Price);
                }
                else
                {
                    products = products.Where(m => m.Price < searchModel.Price);
                }
            }
            return products.ToEnumerable();
        }
        [HttpPost("LikeName")]
        public  IEnumerable<Product> SearchByNames([FromBody]SearchModel name)
        {
            var product = from s in _context.Products
                          where EF.Functions.Like(s.Name.ToUpper(), $"%{name.Name.ToUpper()}%") select s;
            return product;

        }
    }
}
