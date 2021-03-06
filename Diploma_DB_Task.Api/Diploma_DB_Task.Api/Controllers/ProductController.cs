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
        public async Task<int> AddProduct(Product3778 product)
        {
            var param1 = new SqlParameter("@PPRODNAME", product.Prodname);
            var param2 = new SqlParameter("@PBUYPRICE", product.Buyprice);
            var param3 = new SqlParameter("@PSELLPRICE", product.Sellprice);
            var out1 = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "EXEC @ReturnVal = ADD_PRODUCT @PPRODNAME, @PBUYPRICE, @PSELLPRICE";

            await _context.Database.ExecuteSqlRawAsync(sql, out1, param1, param2, param3);

            return Convert.ToInt32(out1.Value);

        }

    }
}
