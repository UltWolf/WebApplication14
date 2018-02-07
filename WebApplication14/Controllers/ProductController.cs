using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;

namespace WebApplication14.Controllers {

    [Route("api/Product")]
    public class ProductController : Controller {
        private readonly ApplicationContext _context;
        public ProductController(ApplicationContext context) {
            _context = context;
        }

        

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _context.Products.SingleOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> PutProducts ([FromRoute] int id, [FromBody] Product product) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            if (id != product.ProductId) {
                return BadRequest ();
            }

            _context.Entry (product).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateConcurrencyException) {
                if (!ProductExists (id)) {
                    return NotFound ();
                } else {
                    throw;
                }
            }

            return NoContent ();
        }

  

        [HttpPost]
        public async Task<IActionResult> PostProduct ([FromBody] Product product) {

            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            await _context.Products.AddAsync (product);
            await _context.SaveChangesAsync ();
            return Ok ();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteProduct ([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var product = await _context.Products.SingleOrDefaultAsync (m => m.ProductId == id);
            if (product == null) {
                return NotFound ();
            }

            _context.Products.Remove (product);
            await _context.SaveChangesAsync ();

            return Ok (product);
        }

        private bool ProductExists (int id) {
            return _context.Products.Any (e => e.ProductId == id);
        }
    }

}