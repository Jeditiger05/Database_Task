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
    public class AuthorisedPersonController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public AuthorisedPersonController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        // POST: api/AuthorisedPerson
        [HttpPost]
        public async Task<int> AddAuthorisedPerson(Authorisedperson3778 person)
        {
            var param1 = new SqlParameter("@PFIRSTNAME", person.Firstname);
            var param2 = new SqlParameter("@PSURNAME", person.Surname);
            var param3 = new SqlParameter("@PEMAIL", person.Email);
            var param4 = new SqlParameter("@PPASSWORD", person.Password);
            var param5 = new SqlParameter("@PACCOUNTID", person.Accountid);
            var out1 = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "EXEC @ReturnVal = ADD_AUTHORISED_PERSON @PFIRSTNAME, @PSURNAME, @PEMAIL, @PPASSWORD, @PACCOUNTID";

            await _context.Database.ExecuteSqlRawAsync(sql, out1, param1, param2, param3, param4, param5);

            return Convert.ToInt32(out1.Value);
        }
    }
}
