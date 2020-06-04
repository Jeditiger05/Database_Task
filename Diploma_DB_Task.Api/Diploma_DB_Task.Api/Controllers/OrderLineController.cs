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
    public class OrderLineController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public OrderLineController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        // POST: api/OrderLine
        [HttpPost]
        public async Task<IActionResult> AddProductToOrder(Orderline3778 orderline)
        {
            var param1 = new SqlParameter("@PORDERID", orderline.Orderid);
            var param2 = new SqlParameter("@PPRODIID", orderline.Productid);
            var param3 = new SqlParameter("@PQTY", orderline.Quantity);
            var param4 = new SqlParameter("@DISCOUNT", orderline.Discount);

            var sql = "EXEC ADD_PRODUCT_TO_ORDER @PORDERID, @PPRODIID, @PQTY, @DISCOUNT";

            await _context.Database.ExecuteSqlRawAsync(sql, param1, param2, param3, param4);

            return Ok();
        }

        // DELETE: api/OrderLine
        [HttpDelete]
        public async Task<IActionResult> RemoveProductFromOrder(Orderline3778 orderline)
        {
            var param1 = new SqlParameter("@PORDERID", orderline.Orderid);
            var param2 = new SqlParameter("@PPRODIID", orderline.Productid);

            var sql = "EXEC REMOVE_PRODUCT_FROM_ORDER @PORDERID, @PPRODIID";

            await _context.Database.ExecuteSqlRawAsync(sql, param1, param2);

            return Ok();
        }
    }
}
