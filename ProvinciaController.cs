using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAvnzWeb.Models;
using System.Threading.Tasks;

namespace ProyectoPrograAvnzWeb.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly Db_Context_SYS _context;

        public ProvinciaController(Db_Context_SYS context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var provincias = await _context.Provincias
                .Include(p => p.Departamento)
                .Include(p => p.Distritos)
                .ToListAsync();
            return View(provincias);
        }

        public async Task<IActionResult> Details(string id)
        {
            var provincia = await _context.Provincias
                .Include(p => p.Departamento)
                .Include(p => p.Distritos)
                .FirstOrDefaultAsync(p => p.IdProvincia == id);

            if (provincia == null)
            {
                return NotFound();
            }
            return View(provincia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Provincias.Add(provincia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provincia);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            return View(provincia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Provincia provincia)
        {
            if (id != provincia.IdProvincia || !ModelState.IsValid)
            {
                return View(provincia);
            }

            var provinciaExistente = await _context.Provincias.FindAsync(id);
            if (provinciaExistente == null)
            {
                return NotFound();
            }

            provinciaExistente.Descripcion = provincia.Descripcion;
            provinciaExistente.IdDepartamento = provincia.IdDepartamento;

            _context.Provincias.Update(provinciaExistente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            _context.Provincias.Remove(provincia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}