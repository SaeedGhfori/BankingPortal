using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZarinPal_MVC.Models;

namespace ZarinPal_MVC.Controllers
{
    public class HomeController : Controller
    {
        ZarinPal_MVCContext db=new ZarinPal_MVCContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Payment(int id)
        {

            var product = db.Products.Find(id);


            Order order=new Order();
            order.DateTime=DateTime.Now;
            order.IsFinaly = false;
            order.Sum = product.Price;

            db.Orders.Add(order);
            db.SaveChanges();

            System.Net.ServicePointManager.Expect100Continue = false;
            ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPal.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;

            int Status = zp.PaymentRequest("YOUR-ZARINPAL-MERCHANT-CODE", order.Sum, "تست درگاه زرین پال در تاپ لرن", "Iman@Madaeny.com", "09124140939", "http://localhost:45233/Home/Verify/"+order.OrderID, out Authority);

            if (Status == 100)
            {
               // Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
                Response.Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
            }
            else
            {
                ViewBag.Error = "Error : " + Status;
            }
            return View();
        }

        public ActionResult Verify(int id)
        {
            var order = db.Orders.Find(id);


            if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
            {
                if (Request.QueryString["Status"].ToString().Equals("OK"))
                {
                    int Amount = order.Sum;
                    long RefID;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPal.PaymentGatewayImplementationServicePortTypeClient();

                    int Status = zp.PaymentVerification("YOUR-ZARINPAL-MERCHANT-CODE", Request.QueryString["Authority"].ToString(), Amount, out RefID);

                    if (Status == 100)
                    {
                        order.IsFinaly = true;
                        db.SaveChanges();
                        ViewBag.IsSuccess = true;
                        ViewBag.RefId = RefID;
                       // Response.Write("Success!! RefId: " + RefID);
                    }
                    else
                    {
                        ViewBag.Status = Status;
                    }

                }
                else
                {
                    Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                }
            }
            else
            {
                Response.Write("Invalid Input");
            }
            return View();
        }
    }
}