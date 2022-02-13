using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Services;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoAnexoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoAnexoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloRecursoAnexoAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoAnexo = await _db.GetModeloRecursoAnexo(id.Value);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoAnexo);
        }

        public async Task<IActionResult> Create(int? recursoId)
        {
            var modeloRecursoAnexo = new ModeloRecursoAnexo();

            int? modeloId;

            if (recursoId.HasValue)
            {
                var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(recursoId.Value);

                if (modeloRecurso == null)
                {
                    modeloId = null;

                    ViewData["RecursoId"] = new HashSet<SelectListItem>();
                }
                else
                {
                    modeloId = modeloRecurso.ModeloId;

                    ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet.Where(mr => mr.ModeloId == modeloId.Value), "Id", "Descricao", recursoId.Value);
                }

                modeloRecursoAnexo.RecursoId = recursoId.Value;

                ViewData["Parent"] = "ModeloRecurso";
            }
            else
            {
                modeloId = null;
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);
            
            return View(modeloRecursoAnexo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecursoId,Nome,Arquivo,Id")] ModeloRecursoAnexo modeloRecursoAnexo, string? parent, int? modeloId, string? command)
        {
            if (command == "SelectModelo")
            {
                ModelState.Clear();

                if (modeloId.HasValue)
                {
                    ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet.Where(mr => mr.ModeloId == modeloId.Value), "Id", "Descricao");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _db.Add(modeloRecursoAnexo);

                    await _db.SaveChangesAsync();

                    if (parent == "ModeloRecurso")
                    {
                        return RedirectToAction("Details", "ModeloRecurso", new { id = modeloRecursoAnexo.RecursoId });
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);

            ViewData["Parent"] = parent;

            return View(modeloRecursoAnexo);
        }

        public async Task<IActionResult> Edit(int? id, string? parent, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet.FindAsync(id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            int? modeloId;

            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(modeloRecursoAnexo.RecursoId);

            if (modeloRecurso == null)
            {
                return Problem();
            }
            else
            {
                modeloId = modeloRecurso.ModeloId;
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet.Where(mr => mr.ModeloId == modeloId.Value), "Id", "Descricao", modeloRecursoAnexo.RecursoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecursoAnexo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecursoId,Nome,Arquivo,Id")] ModeloRecursoAnexo modeloRecursoAnexo, string? parent, string? from, int? modeloId, string? command)
        {
            if (id != modeloRecursoAnexo.Id)
            {
                return NotFound();
            }

            if (command == "SelectModelo")
            {
                ModelState.Clear();

                if (modeloId.HasValue)
                {
                    ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet.Where(mr => mr.ModeloId == modeloId.Value), "Id", "Descricao");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _db.Update(modeloRecursoAnexo);

                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_db.ExistsEntity<ModeloRecursoObservacao>(modeloRecursoAnexo.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    if (parent == "ModeloRecurso")
                    {
                        return RedirectToAction("Details", "ModeloRecurso", new { id = modeloRecursoAnexo.RecursoId });
                    }

                    if (from == "Details")
                    {
                        return RedirectToAction(nameof(Details), new { id });
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecursoAnexo);
        }

        public async Task<IActionResult> Delete(int? id, string? parent)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoAnexo = await _db.GetModeloRecursoAnexo(id.Value);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            ViewData["Parent"] = parent;

            return View(modeloRecursoAnexo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
        {
            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet.FindAsync(id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoAnexoSet.Remove(modeloRecursoAnexo);
            
            await _db.SaveChangesAsync();

            if (parent == "ModeloRecurso")
            {
                return RedirectToAction("Details", "ModeloRecurso", new { id = modeloRecursoAnexo.RecursoId });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
