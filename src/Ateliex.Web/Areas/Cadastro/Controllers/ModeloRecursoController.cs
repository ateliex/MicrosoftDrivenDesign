using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloRecursoAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.GetModeloRecurso(id.Value);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            return View(modeloRecurso);
        }

        public IActionResult Create(int? modeloId, int? tipoId)
        {
            var modeloRecurso = new ModeloRecurso();

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome");

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome");

            if (modeloId.HasValue)
            {
                modeloRecurso.ModeloId = modeloId.Value;

                ViewData["Parent"] = "Modelo";
            }

            if (tipoId.HasValue)
            {
                modeloRecurso.TipoId = tipoId.Value;

                ViewData["Parent"] = "ModeloRecursoTipo";
            }

            return View(modeloRecurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModeloId,TipoId,Descricao,Custo,Unidades")] ModeloRecurso modeloRecurso, string? parent)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecurso);

                await _db.SaveChangesAsync();

                if (parent == "Modelo")
                {
                    return RedirectToAction("Details", "Modelo", new { id = modeloRecurso.ModeloId });
                }

                if (parent == "ModeloRecursoTipo")
                {
                    return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecurso.TipoId });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            ViewData["Parent"] = parent;

            return View(modeloRecurso);
        }

        public async Task<IActionResult> Edit(int? id, string? parent, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id.Value);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModeloId,TipoId,Descricao,Custo,Unidades")] ModeloRecurso modeloRecurso, string? parent, string? from)
        {
            if (id != modeloRecurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecurso);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.ExistsEntity<ModeloRecurso>(modeloRecurso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (parent == "Modelo")
                {
                    return RedirectToAction("Details", "Modelo", new { id = modeloRecurso.ModeloId });
                }

                if (parent == "ModeloRecursoTipo")
                {
                    return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecurso.TipoId });
                }

                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecurso);
        }

        public async Task<IActionResult> Delete(int? id, string? parent)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.GetModeloRecurso(id.Value);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            ViewData["Parent"] = parent;

            return View(modeloRecurso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
        {
            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            _db.Remove(modeloRecurso);

            await _db.SaveChangesAsync();

            if (parent == "Modelo")
            {
                return RedirectToAction("Details", "Modelo", new { id = modeloRecurso.ModeloId });
            }

            if (parent == "ModeloRecursoTipo")
            {
                return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecurso.TipoId });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
