using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOA_CA2.contexts;
using SOA_CA2.models;

namespace SOA_CA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_invoiceController : ControllerBase
    {
        private readonly Customer_invoiceDB _context;

        public Customer_invoiceController(Customer_invoiceDB context)
        {
            _context = context;
        }

        // GET: api/Customer_invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_invoice>>> GetCustomer_invoice()
        {
            if (_context.Customer_invoice == null)
            {
                return NotFound();
            }
            return await _context.Customer_invoice.ToListAsync();
        }

        // GET: api/Customer_invoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_invoice>> GetCustomer_invoice(int id)
        {
            if (_context.Customer_invoice == null)
            {
                return NotFound();
            }
            var customer_invoice = await _context.Customer_invoice.FindAsync(id);

            if (customer_invoice == null)
            {
                return NotFound();
            }

            return customer_invoice;
        }

        // PUT: api/Customer_invoice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_invoice(int id, Customer_invoice customer_invoice)
        {
            if (id != customer_invoice.customer_id)
            {
                return BadRequest();
            }

            _context.Entry(customer_invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_invoiceExists(id))
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

        // POST: api/Customer_invoice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer_invoice>> PostCustomer_invoice(Customer_invoice customer_invoice)
        {
            if (_context.Customer_invoice == null)
            {
                return Problem("Entity set 'Customer_invoiceDB.Customer_invoice'  is null.");
            }
            _context.Customer_invoice.Add(customer_invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer_invoice", new { id = customer_invoice.customer_id }, customer_invoice);
        }

        // DELETE: api/Customer_invoice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_invoice(int id)
        {
            if (_context.Customer_invoice == null)
            {
                return NotFound();
            }
            var customer_invoice = await _context.Customer_invoice.FindAsync(id);
            if (customer_invoice == null)
            {
                return NotFound();
            }

            _context.Customer_invoice.Remove(customer_invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_invoiceExists(int id)
        {
            return (_context.Customer_invoice?.Any(e => e.customer_id == id)).GetValueOrDefault();
        }
    }
}
