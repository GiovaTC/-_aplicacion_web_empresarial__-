using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Producto producto)
        {
            _context.Productos.Add(producto);

            await _context.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Producto producto)
        {
            var existe = await _context.Productos.FindAsync(id);

            if (existe == null)
                return NotFound();

            existe.Nombre = producto.Nombre;
            existe.Precio = producto.Precio;
            existe.Stock = producto.Stock;

            await _context.SaveChangesAsync();

            return Ok(existe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
                return NotFound();

            _context.Productos.Remove(producto);

            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}
