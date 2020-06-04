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
    public class OrderController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public OrderController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order3778>>> GetAllOpenOrders()
        {
            var sql = "EXEC GET_OPEN_ORDERS";

            return await _context.Order3778.FromSqlRaw(sql).ToListAsync();
        }

        // GET: api/Order/id
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderById(int id)
        {
            var param = new SqlParameter("@PORDERID", id);

            var sql = "EXEC GET_ORDER_BY_ID @PORDERID";

            return await _context.OrderDetails.FromSqlRaw(sql, param).ToListAsync();
        }

        //POST: api/Order
        [HttpPost]
        public async Task<int> CreateOrder(Order3778 order)
        {
            var param1 = new SqlParameter("@PSHIPPINGADDRESS", order.Shippingaddress);
            var param2 = new SqlParameter("@PUSERID", order.Userid);
            var out1 = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                DbType = System.Data.DbType.String,
                Size = 200,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "EXEC @ReturnVal = CREATE_ORDER @PSHIPPINGADDRESS, @PUSERID";

            await _context.Database.ExecuteSqlRawAsync(sql, out1, param1, param2);

            return Convert.ToInt32(out1.Value);

        }

        [HttpPut]
        public async Task<IActionResult> FullFillOrder(int orderid)
        {
            var param = new SqlParameter("@PORDERID", orderid);

            var sql = "EXEC FULLFILL_ORDER @PORDERID";

            await _context.Database.ExecuteSqlRawAsync(sql, param);

            return Accepted();
        }
    }
}
