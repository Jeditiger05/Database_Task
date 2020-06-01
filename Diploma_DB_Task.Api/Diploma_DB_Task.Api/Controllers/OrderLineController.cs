using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diploma_DB_Task.Api.Models;

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

        // GET: api/OrderLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderline3778>>> GetOrderline3778()
        {
            return await _context.Orderline3778.ToListAsync();
        }

        // GET: api/OrderLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderline3778>> GetOrderline3778(int id)
        {
            var orderline3778 = await _context.Orderline3778.FindAsync(id);

            if (orderline3778 == null)
            {
                return NotFound();
            }

            return orderline3778;
        }

        // PUT: api/OrderLine/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderline3778(int id, Orderline3778 orderline3778)
        {
            if (id != orderline3778.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(orderline3778).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Orderline3778Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderLine
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orderline3778>> PostOrderline3778(Orderline3778 orderline3778)
        {
            _context.Orderline3778.Add(orderline3778);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Orderline3778Exists(orderline3778.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderline3778", new { id = orderline3778.Orderid }, orderline3778);
        }

        // DELETE: api/OrderLine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orderline3778>> DeleteOrderline3778(int id)
        {
            var orderline3778 = await _context.Orderline3778.FindAsync(id);
            if (orderline3778 == null)
            {
                return NotFound();
            }

            _context.Orderline3778.Remove(orderline3778);
            await _context.SaveChangesAsync();

            return orderline3778;
        }

        private bool Orderline3778Exists(int id)
        {
            return _context.Orderline3778.Any(e => e.Orderid == id);
        }
    }
}
