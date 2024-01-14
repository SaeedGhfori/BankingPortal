using BankingPortalCore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Endpoint.Models;
using ZarinpalSandbox;

namespace Web.Endpoint.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext context;
        public HomeController(DataBaseContext context)
        {
            this.context = context;
        }
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = context.Orders.Find(id);
                var payment = new Payment(order.Sum);
                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    context.Orders.Update(order);
                    context.SaveChanges();

                    ViewBag.code = res.RefId;
                    return View();
                }
            }

            return NotFound();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
