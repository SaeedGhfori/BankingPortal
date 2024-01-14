using BankingPortalCore.Data;
using BankingPortalCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZarinpalSandbox;

namespace BankingPortalCore.Services
{
    public class PaymentService
    {
        DataBaseContext context;
        public PaymentService(DataBaseContext context)
        {
            this.context = context;
        }
    }
}
