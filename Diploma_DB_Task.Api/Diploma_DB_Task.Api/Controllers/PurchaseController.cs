﻿using System;
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
    public class PurchaseController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public PurchaseController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        // POST: api/Purchase
        [HttpPost]
        public async void PurchaseStock(Purchaseorder3778 purchase)
        {
            var p1 = new SqlParameter("@PPRODID", purchase.Productid);
            var p2 = new SqlParameter("@PLOCID", purchase.Locationid);
            var p3 = new SqlParameter("@PQTY", purchase.Quantity);

            var sql = "EXEC PURCHASE_STOCK @PPRODID, @PLOCID, @PQTY";

            await _context.Database.ExecuteSqlRawAsync(sql, p1, p2, p3);
        }

    }
}
