using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;


namespace WebApplication14.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _context;
        public ProductsController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpPost()]
        public async Task<IActionResult> GetProducts([FromBody]ParametresSortModel sortModel)
        {
            int pageSize = 3;
            int page = 1;
            if (sortModel.NumberPager != null)
            {
                page = (int)sortModel.NumberPager;

            }
            
            int count;
            IQueryable<Product> source;
            List<Product> items;
            if (sortModel.Parametre == "Name") {
                if (sortModel.variantSort)
                {
                    source = _context.Products.OrderBy(m => m.Name);
                }
                else
                {
                    source = _context.Products.OrderByDescending(m => m.Name);
                }
            }else if(sortModel.Parametre == "Category") {
                if (sortModel.variantSort)
                {
                    source = _context.Products.OrderBy(m => m.Category);
                }
                else
                {
                    source = _context.Products.OrderByDescending(m => m.Category);
                }
            }
            else if(sortModel.Parametre == "Country")
            {if (sortModel.variantSort)
                {
                    source = _context.Products.OrderBy(m => m.Country);
                }
                else
                {
                    source = _context.Products.OrderByDescending(m => m.Country);
                }
            }
            else
            {
                if (sortModel.variantSort)
                {
                    source = _context.Products.OrderBy(m => m.Price);
                }
                else
                {
                    source = _context.Products.OrderByDescending(m => m.Price);
                }
       
            }
            count = await source.CountAsync();
            items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PaginationProductModel pgm = new PaginationProductModel(count, page, pageSize);
            ProductsModel viewModel = new ProductsModel
            {
                pgm = pgm,
                products = items
            };
            return Ok(viewModel);

        }
    }
}