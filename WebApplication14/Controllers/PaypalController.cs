using BraintreeHttp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayPal.Core;
using PayPal.Payments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Helpers;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;
using WebApplication14.Services;

namespace WebApplication14.Controllers
{

    [Route("paypal")]
    public class PaypalController : Controller
    {
        private const string baseurl = "localhost:55022";
        private readonly ApplicationContext _context;
        public IHostingEnvironment _environment { get; set; }
        public PaypalController(ApplicationContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpGet("create-payment/{id}")]
        public async Task<IActionResult> ConfirmAsync([FromRoute]string id)
        {
            var environment = new SandboxEnvironment("Acc2-UPp-z25_Olh73h5VZB3XjR16eUKtL2lHoIc27IJn8-2f5R8-Kish229pYjzdy18KR8khHJRQO5Q", "EIb_0hbZQPAEioCGLAzVpn87zRswB7zLAoRtda06Oc4IhrDAmtGYAI2z6xYplX6TdARnsuVh2TC3tHNM");
            var client = new PayPalHttpClient(environment);
            string idUser = id;
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = GetTransactionsList(id),
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = "http://localhost:55022/paypal/cancel",
                    ReturnUrl = "http://localhost:55022/paypal/execute-payment"
                },
                Payer = new Payer()
                {

                    PaymentMethod = "paypal"
                },

            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);
            var path = CreateExcelOrder.Create(_context.Orders.Where(m => m.UserId == id).ToList(), id,_environment);

            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                LinkDescriptionObject approvalLink = PaypalHelpers.findApprovalLink(result.Links);
                var orders = _context.Orders.Include(m => m.Product).Where(m => m.UserId == id).Where(m => m.IsConfirm == false);
                await orders.ForEachAsync(m => m.Paymentid = result.Id);
                await _context.SaveChangesAsync();
                return Ok( new ConfirmModel{ confirmPath = approvalLink.Href.ToString(), excelPath = path});
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                return NoContent();
            }

        }

        [HttpGet("execute-payment")]
        public async Task<IActionResult> Execute(string paymentId, string PayerId)
        {
            var environment = new SandboxEnvironment("Acc2-UPp-z25_Olh73h5VZB3XjR16eUKtL2lHoIc27IJn8-2f5R8-Kish229pYjzdy18KR8khHJRQO5Q", "EIb_0hbZQPAEioCGLAzVpn87zRswB7zLAoRtda06Oc4IhrDAmtGYAI2z6xYplX6TdARnsuVh2TC3tHNM");
            var client = new PayPalHttpClient(environment);
            
            PaymentExecuteRequest request = new PaymentExecuteRequest(paymentId);
            request.RequestBody(new PaymentExecution()
            {
                PayerId = PayerId
            });
             await _context.Orders.Where(m => m.Paymentid == paymentId).ForEachAsync(m => m.IsConfirm = true);
            await _context.SaveChangesAsync();
            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                return Redirect("sold");
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                return BadRequest(debugId);
            }
        }
        private List<Transaction> GetTransactionsList(string id)
        {

            //var transactionList = new List<Transaction>();
            var TransList = new List<Item>();
            var orders = _context.Orders.Include(m => m.Product).Where(m => m.UserId == id).Where(m=> m.IsConfirm == false);
            decimal totalPrice = 0;
            foreach (var item in orders)
            {
                totalPrice += item.Product.Price * item.Count;
            }
            foreach (var order in orders)
            {
                TransList.Add(new Item()
            {
                Price = decimal.Round(order.Product.Price, 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture),
                Quantity = order.Count.ToString(),
                Name = order.Product.Name,
                Currency = "USD",
                Sku = "sku"
            });
            }
            //    transactionList.Add(new Transaction()
            //    {
            //        Description = "Transaction description.",
            //        Amount = new Amount()
            //        {
            //            Currency = "USD",
            //            Total = "100.00"

            //        },
            //        ItemList = new ItemList() {
            //            Items = TransList,
            //        }
            //    });

            List<Transaction> transakList = new List<Transaction>() {
                new Transaction()
            {
                Amount = new Amount()
                {
                    Total = decimal.Round(totalPrice, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture),
                    Currency = "USD",
                },
                ItemList = new ItemList()
                {
                    Items = new List<Item>(TransList)
                    {     
                }
                },
                Description = "JustSimplePayment",
            }
            };
            
            return  transakList;
        }



        private static RedirectUrls GetReturnUrls(string baseUrl, string intent)
        {
            var returnUrl = intent == "sale" ? "/Home/PaymentSuccessful" : "/Home/AuthorizeSuccessful";

            return new RedirectUrls()
            {
                CancelUrl = baseUrl + "/Home/PaymentCancelled",
                ReturnUrl = baseUrl + returnUrl
            };
        }
    }


        //    [Route("new")]
        //    public void New()
        //    {
        //        var config = ConfigManager.Instance.GetProperties();
        //        var accessToken = new OAuthTokenCredential("Acc2-UPp-z25_Olh73h5VZB3XjR16eUKtL2lHoIc27IJn8-2f5R8-Kish229pYjzdy18KR8khHJRQO5Q","EIb_0hbZQPAEioCGLAzVpn87zRswB7zLAoRtda06Oc4IhrDAmtGYAI2z6xYplX6TdARnsuVh2TC3tHNM").GetAccessToken();
        //        var apiContext = new APIContext(accessToken);

        //        // Make an API call
        //        var payment = new Payment()
        //        {
        //            Intent = "sale",
        //            Payer = new Payer
        //            {
        //                PaymentMethod = "paypal"
        //            },
        //            Transactions = new List<Transaction>
        //     {
        //       new Transaction
        //      {
        //        Description = "Transaction description.",
        //        InvoiceNumber = "001",
        //        Amount = new Amount
        //        {
        //            Currency = "USD",
        //            Total = "100.00",
        //            Details = new AmountDetails
        //            {
        //                Tax = "15",
        //                Shipping = "10",
        //                Subtotal = "75"
        //            }
        //        },
        //        ItemList = new ItemList
        //        {
        //            Items = new List<Item>
        //            {
        //                new Item
        //                {
        //                    Name = "Item Name",
        //                    Currency = "USD",
        //                    Price = "15",
        //                    Quantity = "5",
        //                    Sku = "sku"
        //                }
        //            }
        //        }
        //    }
        //},
        //            RedirectUrls = new RedirectUrls
        //            {
        //                ReturnUrl = "http://mysite.com/return",
        //                CancelUrl = "http://mysite.com/cancel"
        //            }
        //        };
        



        }
          


