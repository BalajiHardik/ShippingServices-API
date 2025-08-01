using Microsoft.AspNetCore.Mvc;
using ShippingServices.Data;
using Microsoft.EntityFrameworkCore;
using ShippingServices.Model;

namespace ShippingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingServiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ShippingServiceController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shipments = await _context.ShippingItems.ToListAsync();
            return Ok(shipments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var shipment = await _context.ShippingItems.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShippingItem shippingItem)
        {
            _context.ShippingItems.Add(shippingItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), shippingItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShippingItem shippingItem)
        {
            var shipment = await _context.ShippingItems.FindAsync(id);
            if(shipment == null) return NotFound();
            shipment.ItemName = shippingItem.ItemName;
            shipment.ItemDescription = shippingItem.ItemDescription;
            shipment.ItemShippedDate = shippingItem.ItemShippedDate;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shipment =await _context.ShippingItems.FindAsync(id);
            if (shipment == null) return NotFound();
            _context.ShippingItems.Remove(shipment);
            return NoContent();
        }

    }
}
