using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAvnzWeb.Models;
using System.Threading.Tasks;

namespace ProyectoPrograAvnzWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly Db_Context_SYS _context;

        public ProductoController(Db_Context_SYS context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de productos
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                                          .Include(p => p.Marca)
                                          .Include(p => p.Categoria)
                                          .ToListAsync();
            return View(productos);
        }

        // Acción para mostrar el detalle de un producto
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _context.Productos
                                         .Include(p => p.Marca)
                                         .Include(p => p.Categoria)
                                         .FirstOrDefaultAsync(p => p.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // Acción para crear un nuevo producto (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Acción para crear un nuevo producto (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var nuevoProducto = new Producto
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    IdMarca = producto.IdMarca,
                    IdCategoria = producto.IdCategoria,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    RutaImagen = producto.RutaImagen,
                    Activo = producto.Activo,
                    FechaRegistro = producto.FechaRegistro
                };

                _context.Productos.Add(nuevoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // Acción para editar un producto (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // Acción para editar un producto (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.IdProducto || !ModelState.IsValid)
            {
                return View(producto);
            }

            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null)
            {
                return NotFound();
            }

            // Actualizando propiedades
            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.IdMarca = producto.IdMarca;
            productoExistente.IdCategoria = producto.IdCategoria;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;
            productoExistente.RutaImagen = producto.RutaImagen;
            productoExistente.Activo = producto.Activo;
            productoExistente.FechaRegistro = producto.FechaRegistro;

            _context.Productos.Update(productoExistente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Acción para eliminar un producto
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
