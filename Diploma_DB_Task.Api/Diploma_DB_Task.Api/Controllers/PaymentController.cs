using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diploma_DB_Task.Api.Models;
using Microsoft.Data.SqlClient;

namespace Diploma_DB_Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public PaymentController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task MakeAccountPayment(Accountpayment3778 payment)
        {
            var param1 = new SqlParameter("@PACCOUNTID", payment.Accountid);
            var param2 = new SqlParameter("@PAMOUNT", payment.Amount);

            var sql = "EXEC MAKE_ACCOUNT_PAYMENT @PACCOUNTID, @PAMOUNT";

            await _context.Database.ExecuteSqlRawAsync(sql, param1, param2);
        }

    }
}
