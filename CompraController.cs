using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAvnzWeb.Models;
using System.Threading.Tasks;

namespace ProyectoPrograAvnzWeb.Controllers
{
    public class CompraController : Controller
    {
        private readonly Db_Context_SYS _context;

        public CompraController(Db_Context_SYS context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var compras = await _context.Compras
                .Include(c => c.Usuario)
                .ToListAsync();
            return View(compras);
        }

        public async Task<IActionResult> Details(int id)
        {
            var compra = await _context.Compras
                .Include(c => c.Usuario)
                .Include(c => c.DetallesCompra)
                    .ThenInclude(dc => dc.Producto)
                .FirstOrDefaultAsync(c => c.IdCompra == id);

            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Compra compra)
        {
            if (id != compra.IdCompra || !ModelState.IsValid)
            {
                return View(compra);
            }

            var compraExistente = await _context.Compras.FindAsync(id);
            if (compraExistente == null)
            {
                return NotFound();
            }

            compraExistente.TotalProducto = compra.TotalProducto;
            compraExistente.Total = compra.Total;
            compraExistente.Contacto = compra.Contacto;
            compraExistente.Telefono = compra.Telefono;
            compraExistente.Direccion = compra.Direccion;
            compraExistente.IdDistrito = compra.IdDistrito;

            _context.Compras.Update(compraExistente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
