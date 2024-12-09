using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAvnzWeb.Models;
using System.Threading.Tasks;

namespace ProyectoPrograAvnzWeb.Controllers
{
    public class MarcaController : Controller
    {
        private readonly Db_Context_SYS _context;

        public MarcaController(Db_Context_SYS context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var marcas = await _context.Marcas.ToListAsync();
            return View(marcas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.IdMarca == id);

            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Marca marca)
        {
            if (id != marca.IdMarca || !ModelState.IsValid)
            {
                return View(marca);
            }

            var marcaExistente = await _context.Marcas.FindAsync(id);
            if (marcaExistente == null)
            {
                return NotFound();
            }

            marcaExistente.Descripcion = marca.Descripcion;

            _context.Marcas.Update(marcaExistente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}