using BankingPortalCore.Data;
using BankingPortalCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZarinpalSandbox;

namespace BankingPortalCore.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class BankingController : ControllerBase
    //{
    //    DataBaseContext context;
    //    public BankingController(DataBaseContext context)
    //    {
    //        this.context = context;
    //    }


    //    [HttpPost]
    //    [Route("online-payment")]
    //    public IActionResult OnlinePayment(int id)
    //    {
    //        if (HttpContext.Request.Query["Status"] != "" &&
    //            HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
    //            HttpContext.Request.Query["Authority"] != "")
    //        {
    //            string authority = HttpContext.Request.Query["Authority"].ToString();
    //            var order = context.Orders.Find(id);
    //            var payment = new Payment(order.Sum);
    //            var res = payment.Verification(authority).Result;
    //            if (res.Status == 100)
    //            {
    //                order.IsFinaly = true;
    //                context.Orders.Update(order);
    //                context.SaveChanges();

    //                return Ok(res.RefId);
    //            }
    //        }

    //        return NotFound();
    //    }

    //    [HttpPost]
    //    [Route("payment")]
    //    public IActionResult Payment()
    //    {
    //        var order = context.Orders.SingleOrDefault(o => !o.IsFinaly);
    //        if (order == null)
    //        {
    //            return NotFound();
    //        }

    //        var payment = new Payment(order.Sum);
    //        var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}",
    //            "https://localhost:44359/api/Banking/online-payment/" + order.OrderId, "h-soft.ir", "09106372025");
    //        if (res.Result.Status == 100)
    //        {
    //            //publish
    //            //return Redirect("https://zarinpal.com/pg/StartPay/" + res.Result.Authority);

    //            //test
    //            return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }

    //        return null;
    //    }

    //    [HttpGet]
    //    [Route("order-detail")]
    //    public IActionResult GetOrderDetail()
    //    {
    //        var result = context.OrderDetails.ToList();
    //        return Ok(result);
    //    }

    //    [HttpGet]
    //    [Route("order")]
    //    public IActionResult GetOrder()
    //    {
    //        var result = context.Orders.ToList();
    //        return Ok(result);
    //    }

    //    [HttpGet]
    //    [Route("product")]
    //    public IActionResult GetProduct()
    //    {
    //        var result = context.Products.ToList();
    //        return Ok(result);
    //    }
    //}
}
