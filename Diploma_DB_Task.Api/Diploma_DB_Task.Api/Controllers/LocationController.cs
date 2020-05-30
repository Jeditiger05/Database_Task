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

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Location3778>>>  GetLocationById(string id)
        {
            return await _context.Location3778.FromSqlRaw($"EXEC GET_LOCATION_BY_ID @PLOCID = {id}").ToListAsync();
        }

        [HttpPost]
        public string AddLocation(Location3778 location)
        {
            var out1 = new SqlParameter
            {
                ParameterName = "@LOCID",
                DbType = System.Data.DbType.String,
                Size = Int32.MaxValue,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = $"EXEC ADD_LOCATION '{location.Locationid}', '{location.Locname}', '{location.Address}', '{location.Manager}', @LOCID OUT";
            _context.Database.ExecuteSqlRaw(sql, out1);

            return out1.Value.ToString();
        }

        // GET: api/Location 
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Location3778>>> GetLocation3778()
        //{
        //    return await _context.Location3778.ToListAsync();
        //}

        // GET: api/Location/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Location3778>> GetLocation3778(string id)
        //{
        //    var location3778 = await _context.Location3778.FindAsync(id);

        //    if (location3778 == null)
        //    {
        //        return NotFound();
        //    }

        //    return location3778;
        ////}

        //// PUT: api/Location/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLocation3778(string id, Location3778 location3778)
        //{
        //    if (id != location3778.Locationid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(location3778).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Location3778Exists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Location
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Location3778>> PostLocation3778(Location3778 location3778)
        //{
        //    _context.Location3778.Add(location3778);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (Location3778Exists(location3778.Locationid))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetLocation3778", new { id = location3778.Locationid }, location3778);
        //}

        //// DELETE: api/Location/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Location3778>> DeleteLocation3778(string id)
        //{
        //    var location3778 = await _context.Location3778.FindAsync(id);
        //    if (location3778 == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Location3778.Remove(location3778);
        //    await _context.SaveChangesAsync();

        //    return location3778;
        //}

        //private bool Location3778Exists(string id)
        //{
        //    return _context.Location3778.Any(e => e.Locationid == id);
        //}
    }
}
