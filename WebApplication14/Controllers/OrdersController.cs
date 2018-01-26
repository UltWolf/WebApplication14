using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;

 namespace WebApplication14.Controllers {
  
    [Route ("api/Orders")]
    public class OrdersController : Controller {
        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
        public OrdersController (ApplicationContext context, UserManager<AppUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Buy (Order order) {
            var product = await _context.Products.SingleOrDefaultAsync (m => m.ProductId ==  order.IdProduct);
            var result = await AddOrder(product,order.Count);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
          
        }
      
        [HttpPost ("{id}")]
        public async Task<IActionResult> BuyByRoute([FromRoute] int id,int count)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            var result = await AddOrder(product, count);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<bool> AddOrder(Product product, int Count)
        {
            //var user = await GetCurrentUser();
            //Order orderBD = await IsIdentityProduct(user.Id, product.ProductId);
            //if (orderBD == null)
            //{
            //    Order orderInDb = new Order() { UserId = user.Id, Product = product, User = user, IdProduct = product.ProductId, DateOfOrder = DateTime.Now, Count = Count };
            //    await _context.AddAsync(orderInDb);
            //}
            //else
            //{
            //    orderBD.Count += Count;
            //}
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> IsIdentityProduct(string userId, int productId)
        {
            var Order = await _context.Orders.Where(m => m.UserId == userId).FirstOrDefaultAsync(f => f.IdProduct == productId);
            return Order;
        }

        public async Task<IActionResult> DeleteOneItem ([FromRoute] int id) {
            var order = _context.Orders.SingleOrDefaultAsync (m => m.OrderId== id);
            if (order != null) {
                var result = _context.Remove (order);
                await _context.SaveChangesAsync ();
                return Ok ();
            }
            return NotFound ();
        }
        public async Task<IActionResult> DeleteAll () {
            //AppUser user = await GetCurrentUser ();
            //var orders = _context.Orders.Where (m => m.UserId == user.Id);

            //if (orders != null) {
            //    _context.Remove (orders);
            //    await _context.SaveChangesAsync ();
            //    return Ok ();
            //}
            return NotFound ();
        }
   

        [HttpGet ("ConfirmOrder/{idOrder}")]
        public async Task<IActionResult> ConfirmOrder ([FromRoute] int idOrder) {
            var order = await _context.Orders.SingleOrDefaultAsync (m => m.OrderId == idOrder);
            if (order != null) {
                order.IsConfirm = true;
                await _context.SaveChangesAsync ();
                return Ok ();
            }
            return NotFound ();
        }
    }
}