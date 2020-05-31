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
    public class LocationController : ControllerBase
    {
        private readonly Diploma_DB_TaskContext _context;

        public LocationController(Diploma_DB_TaskContext context)
        {
            _context = context;
        }

        [HttpGet]

        // GET: api/Location 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location3778>>> GetAllLocations()
        {
            return await _context.Location3778.ToListAsync();
        }

        // GET: api/Location/id
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Location3778>>> GetLocationById(string id)
        {
            var param = new SqlParameter("@PLOCID", id);

            return await _context.Location3778.FromSqlRaw("EXEC GET_LOCATION_BY_ID @PLOCID", param).ToListAsync();
        }

        // POST: api/Location
        [HttpPost]
        public async Task<string> AddLocation(Location3778 location)
        {
            var p1 = new SqlParameter("@PLOCID", location.Locationid);
            var p2 = new SqlParameter("@PLOCNAME", location.Locname);
            var p3 = new SqlParameter("@PLOCADDRESS", location.Address);
            var p4 = new SqlParameter("@PMANAGER", location.Manager);
            var out1 = new SqlParameter
            {
                ParameterName = "@LOCID",
                DbType = System.Data.DbType.String,
                Size = 8,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "EXEC ADD_LOCATION @PLOCID, @PLOCNAME, @PLOCADDRESS, @PMANAGER, @LOCID OUT";

            await _context.Database.ExecuteSqlRawAsync(sql, p1, p2, p3, p4, out1);

            return out1.Value.ToString();
        }
    }
}
