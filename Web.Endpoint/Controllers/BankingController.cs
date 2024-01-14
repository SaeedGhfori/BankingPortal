using BankingPortalCore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Transactions;
using Web.Endpoint.Models;
using ZarinpalSandbox;

namespace Web.Endpoint.Controllers
{
    public class BankingController : Controller
    {
        //Payment Payment;
        //authority Payment;
        //Transaction Transaction;
        DataBaseContext context;
        public BankingController(DataBaseContext context)
        {
            this.context = context;
        }

        public IActionResult Payment()
        {
            var order = context.Orders.SingleOrDefault(o => !o.IsFinaly);
            if (order == null)
            {
                return NotFound();
            }

            var callBackUrl = "https://localhost:44330/Home/OnlinePayment/" + order.OrderId;
            var description = $"پرداخت فاکتور شرکت HSoft شماره {order.OrderId}";
            var email = "Iman@Madaeny.com";
            var phoneNumber = "09106372025";

            var payment = new Payment(order.Sum);
            var res = payment.PaymentRequest(description, callBackUrl, email, phoneNumber);

            //switch (res.Result.Status)
            //{
            //    case 100:
            //        return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{res.Result.Authority}"); break;
            //    case 101:
            //        return BadRequest("عمليات پرداخت موفق بوده و قبلا PaymentVerification تراكنش انجام شده است"); break;
            //    case -1: return BadRequest("اطلاعات ارسال شده ناقص است"); break;
            //    case -2: return BadRequest("IP و یا مرچنت  کد پذیرنده صحیح نیست"); break;
            //    case -3: return BadRequest("با توجه به محدوديت هاي شاپرك امكان پرداخت با رقم درخواست شده ميسر نمي باشد"); break;
            //    case -4: return BadRequest("سطح تاييد پذيرنده پايين تر از سطح نقره اي است"); break;
            //    case -11: return BadRequest("درخواست مورد نظر يافت نشد"); break;
            //    case -12: return BadRequest("امكان ويرايش درخواست ميسر نمي باشد"); break;
            //    case -21: return BadRequest("هيچ نوع عمليات مالي براي اين تراكنش يافت نشد"); break;
            //    case -22: return BadRequest("تراكنش نا موفق ميباشد"); break;
            //    case -33: return BadRequest("رقم تراكنش با رقم پرداخت شده مطابقت ندارد"); break;
            //    case -34: return BadRequest("سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است"); break;
            //    case -40: return BadRequest("اجازه دسترسي به متد مربوطه وجود ندارد"); break;
            //    case -41: return BadRequest("اطلاعات ارسال شده مربوط به AdditionalData غيرمعتبر ميباشد"); break;
            //    case -42: return BadRequest("مدت زمان معتبر طول عمر شناسه پرداخت بايد بين 30 دقيه تا 45 روز مي باشد"); break;
            //    case -54: return BadRequest("درخواست مورد نظر آرشيو شده است"); break;
            //    default:
            //        return BadRequest();
            //        break;
            //}
            //return null;


            if (res.Result.Status == 100)
            {
                //publish
                //return Redirect("https://zarinpal.com/pg/StartPay/" + res.Result.Authority);

                //test
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{res.Result.Authority}");
            }
            else
            {
                return BadRequest();
            }

            return null;
        }


    }
}
