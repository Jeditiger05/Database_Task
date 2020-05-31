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
    public class ProductController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public ProductController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product3778>>> GetAllProducts()
        {
            return await _context.Product3778.ToListAsync();
        }

        // GET: api/Product/id
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Product3778>>> GetProductById(int id)
        {
            var param = new SqlParameter("@PPRODID", id);

            return await _context.Product3778.FromSqlRaw("EXEC GET_PRODUCT_BY_ID @PPRODID", param).ToListAsync();
        }

        // POST: api/Product
        [HttpPost]
        public int AddProduct(Product3778 product)
        {
            var p1 = new SqlParameter("@PPRODNAME", product.Prodname);
            var p2 = new SqlParameter("@PBUYPRICE", product.Buyprice);
            var p3 = new SqlParameter("@PSELLPRICE", product.Sellprice);
            var out1 = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "EXEC @ReturnVal = ADD_PRODUCT @PPRODNAME, @PBUYPRICE, @PSELLPRICE";

            _context.Database.ExecuteSqlRaw(sql, out1, p1, p2, p3);

            return Convert.ToInt32(out1.Value);

          }

    }
}
