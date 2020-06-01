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
    public class AccountController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public AccountController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        // GET: api/Clientaccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientaccount3778>>> GetAllClientAccounts()
        {
            return await _context.Clientaccount3778.ToListAsync();
        }

        // GET: api/ClientAccount/id
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<ClientAuthPerson>>> GetClientAccountById(int id)
        {
            var param = new SqlParameter("@PACCOUNTID", id);

            return await _context.ClienAuthPerson.FromSqlRaw("EXEC GET_CLIENT_ACCOUNT_BY_ID @PACCOUNTID", param).ToListAsync();
        }

        // POST: api/ClientAccount
        [HttpPost]
        public async Task<int> AddClientAccount(Clientaccount3778 account)
        {
            var param1 = new SqlParameter("@PACCTNAME", account.Acctname);
            var param2 = new SqlParameter("@PBALANCE", account.Balance);
            var param3 = new SqlParameter("@PCREDITLIMIT", account.Creditlimit);
            var out1 = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "EXEC @ReturnVal = ADD_CLIENT_ACCOUNT @PACCTNAME, @PBALANCE, @PCREDITLIMIT";

            await _context.Database.ExecuteSqlRawAsync(sql, out1, param1, param2, param3);

            return Convert.ToInt32(out1.Value);

        }
    }
}
