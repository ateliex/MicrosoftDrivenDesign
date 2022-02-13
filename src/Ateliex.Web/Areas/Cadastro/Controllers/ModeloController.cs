using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.GetModelo(id.Value);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        public IActionResult Create()
        {
            var modelo = new Modelo();

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modelo);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(modelo);
        }

        public async Task<IActionResult> Edit(int? id, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.ModeloSet.FindAsync(id.Value);

            if (modelo == null)
            {
                return NotFound();
            }

            ViewData["From"] = from;

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome")] Modelo modelo, string? from)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modelo);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.ExistsEntity<Modelo>(modelo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["From"] = from;

            return View(modelo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.GetModelo(id.Value);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelo = await _db.ModeloSet.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            _db.ModeloSet.Remove(modelo);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
