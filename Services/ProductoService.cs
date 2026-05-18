using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Services
{
    public class ProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _context.Productos.ToListAsync();
        }

        // BUSCAR POR ID
        public async Task<Producto?> ObtenerPorId(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        // INSERTAR
        public async Task<Producto> Insertar(Producto producto)
        {
            _context.Productos.Add(producto);

            await _context.SaveChangesAsync();

            return producto;
        }

        // ACTUALIZAR
        public async Task<bool> Actualizar(int id, Producto producto)
        {
            var existe = await _context.Productos.FindAsync(id);

            if (existe == null)
                return false;

            existe.Nombre = producto.Nombre;
            existe.Precio = producto.Precio;
            existe.Stock = producto.Stock;

            await _context.SaveChangesAsync();

            return true;
        }

        // ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
                return false;

            _context.Productos.Remove(producto);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}