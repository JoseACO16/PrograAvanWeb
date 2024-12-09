using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAvnzWeb.Models;
using System.Threading.Tasks;

namespace ProyectoPrograAvnzWeb.Controllers
{
    public class DistritoController : Controller
    {
        private readonly Db_Context_SYS _context;

        public DistritoController(Db_Context_SYS context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var distritos = await _context.Distritos
                .Include(d => d.Provincia)
                .ToListAsync();
            return View(distritos);
        }

        public async Task<IActionResult> Details(string id)
        {
            var distrito = await _context.Distritos
                .Include(d => d.Provincia)
                .FirstOrDefaultAsync(d => d.IdDistrito == id);

            if (distrito == null)
            {
                return NotFound();
            }
            return View(distrito);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _context.Distritos.Add(distrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distrito);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var distrito = await _context.Distritos.FindAsync(id);
            if (distrito == null)
            {
                return NotFound();
            }
            return View(distrito);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Distrito distrito)
        {
            if (id != distrito.IdDistrito || !ModelState.IsValid)
            {
                return View(distrito);
            }

            var distritoExistente = await _context.Distritos.FindAsync(id);
            if (distritoExistente == null)
            {
                return NotFound();
            }

            distritoExistente.Descripcion = distrito.Descripcion;
            distritoExistente.IdProvincia = distrito.IdProvincia;
            distritoExistente.IdDepartamento = distrito.IdDepartamento;

            _context.Distritos.Update(distritoExistente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var distrito = await _context.Distritos.FindAsync(id);
            if (distrito == null)
            {
                return NotFound();
            }

            _context.Distritos.Remove(distrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}