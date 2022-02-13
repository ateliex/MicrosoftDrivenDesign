using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoTipoDescricaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoTipoDescricaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloRecursoTipoDescricaoAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipoDescricao = await _db.GetModeloRecursoTipoDescricao(id.Value);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipoDescricao);
        }

        public IActionResult Create(int? tipoId)
        {
            var modeloRecursoTipoDescricao = new ModeloRecursoTipoDescricao();

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome");

            if (tipoId.HasValue)
            {
                modeloRecursoTipoDescricao.TipoId = tipoId.Value;

                ViewData["Parent"] = "ModeloRecursoTipo";
            }

            return View(modeloRecursoTipoDescricao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,Texto,Id")] ModeloRecursoTipoDescricao modeloRecursoTipoDescricao, string? parent)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecursoTipoDescricao);

                await _db.SaveChangesAsync();

                if (parent == "ModeloRecursoTipo")
                {
                    return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecursoTipoDescricao.TipoId });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecursoTipoDescricao.TipoId);

            ViewData["Parent"] = parent;

            return View(modeloRecursoTipoDescricao);
        }

        public async Task<IActionResult> Edit(int? id, string? parent, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDescricaoSet.FindAsync(id);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }
            
            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecursoTipoDescricao.TipoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecursoTipoDescricao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,Texto,Id")] ModeloRecursoTipoDescricao modeloRecursoTipoDescricao, string? parent, string? from)
        {
            if (id != modeloRecursoTipoDescricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecursoTipoDescricao);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.ExistsEntity<ModeloRecursoTipoDescricao>(modeloRecursoTipoDescricao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (parent == "ModeloRecursoTipo")
                {
                    return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecursoTipoDescricao.TipoId });
                }

                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id });
                }

                return RedirectToAction(nameof(Index));
            }
            
            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecursoTipoDescricao.TipoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecursoTipoDescricao);
        }

        public async Task<IActionResult> Delete(int? id, string? parent)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipoDescricao = await _db.GetModeloRecursoTipoDescricao(id.Value);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            ViewData["Parent"] = parent;

            return View(modeloRecursoTipoDescricao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
        {
            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDescricaoSet.FindAsync(id);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoTipoDescricaoSet.Remove(modeloRecursoTipoDescricao);
            
            await _db.SaveChangesAsync();

            if (parent == "ModeloRecursoTipo")
            {
                return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecursoTipoDescricao.TipoId });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
