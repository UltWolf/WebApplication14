using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;


namespace WebApplication14.Controllers {

    [Route("api/Orders")]
    public class OrdersController : Controller {
        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
        public OrdersController(ApplicationContext context, UserManager<AppUser> userManager) {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet("{id}")]
        public  IEnumerable<Order>  GetOrders([FromRoute]string id) {
            var orders = _context.Orders.Include(m=>m.Product).Where(m => m.UserId == id);
            if (orders != null)
            {
                return orders;
            }
            return null;
        }
        [HttpPost("update/{id}")]
        public async Task<IEnumerable<Order>> ChangeOrder([FromRoute]int id,[FromBody] OrderModel model)
        {

            var order = await  _context.Orders.Include(m => m.Product).SingleOrDefaultAsync(m=> m.OrderId == id);
            if (order != null)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                   if(user.Id == model.UserId)
                    {
                        order.Count = model.Count;
                        order.TotalCost = model.Count * order.Product.Price;
                        await  _context.SaveChangesAsync();
                    }

                }
                
            }
            return null;
        }
        public string GetBaseUrl()
        {
            return "api/orders";
        }
        
        [HttpPost ("{id}")]
        public async Task<IActionResult> BuyByRoute([FromRoute] int id,[FromBody]OrderModel model)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            var result = await AddOrder(product, model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<bool> AddOrder(Product product, OrderModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user!=null)
            {
                Order orderBD = await IsIdentityProduct(user.Id, product.ProductId);
                if (orderBD == null)
                {
                    Order orderInDb = new Order() { TotalCost = model.Count *product.Price, UserId = user.Id, Product = product, User = user, IdProduct = product.ProductId, DateOfOrder = DateTime.Now, Count = model.Count };
                    await _context.AddAsync(orderInDb);
                }
                else
                {
                    orderBD.Count = model.Count;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
       
        }


        public async Task<Order> IsIdentityProduct(string userId, int productId)
        {
            var Order = await _context.Orders.Where(m => m.UserId == userId).FirstOrDefaultAsync(f => f.IdProduct == productId);
            return Order;
        }
        [HttpDelete("{id}")]
        public async Task<string> DeleteOneItem ([FromRoute] int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync (m => m.OrderId == id);
            if (order != null) {
                var result = _context.Remove (order);
                await _context.SaveChangesAsync ();
                return "Ok";
            }
            return "NotFound";
        }
        [HttpPost("delete/all/{id}")]
        public async Task<IActionResult> DeleteAll ([FromRoute] string id) {
            var user = await _userManager.FindByIdAsync(id);
            var orders = _context.Orders.Where(m => m.UserId == user.Id).Where(m => m.IsConfirm == false);
            if (orders != null)
            {
                _context.Remove(orders);
                await _context.SaveChangesAsync();
                return Ok();
            }
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
        //Another way
       
        }
}