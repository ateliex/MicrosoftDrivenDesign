using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoObservacaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoObservacaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloRecursoObservacaoAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoObservacao = await _db.GetModeloRecursoObservacao(id.Value);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            return View(modeloRecursoObservacao);
        }

        public async Task<IActionResult> Create(int? recursoId)
        {
            var modeloRecursoObservacao = new ModeloRecursoObservacao();

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

                modeloRecursoObservacao.RecursoId = recursoId.Value;

                ViewData["Parent"] = "ModeloRecurso";
            }
            else
            {
                modeloId = null;
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);

            return View(modeloRecursoObservacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecursoId,Texto")] ModeloRecursoObservacao modeloRecursoObservacao, string? parent, int? modeloId, string? command)
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
                    _db.Add(modeloRecursoObservacao);

                    await _db.SaveChangesAsync();

                    if (parent == "ModeloRecurso")
                    {
                        return RedirectToAction("Details", "ModeloRecurso", new { id = modeloRecursoObservacao.RecursoId });
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);

            ViewData["Parent"] = parent;

            return View(modeloRecursoObservacao);
        }

        public async Task<IActionResult> Edit(int? id, string? parent, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet.FindAsync(id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            int? modeloId;

            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(modeloRecursoObservacao.RecursoId);

            if (modeloRecurso == null)
            {
                return Problem();
            }
            else
            {
                modeloId = modeloRecurso.ModeloId;
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloId);

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet.Where(mr => mr.ModeloId == modeloId.Value), "Id", "Descricao", modeloRecursoObservacao.RecursoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecursoObservacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecursoId,Texto")] ModeloRecursoObservacao modeloRecursoObservacao, string? parent, string? from, int? modeloId, string? command)
        {
            if (id != modeloRecursoObservacao.Id)
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
                        _db.Update(modeloRecursoObservacao);

                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_db.ExistsEntity<ModeloRecursoObservacao>(modeloRecursoObservacao.Id))
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
                        return RedirectToAction("Details", "ModeloRecurso", new { id = modeloRecursoObservacao.RecursoId });
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

            return View(modeloRecursoObservacao);
        }

        public async Task<IActionResult> Delete(int? id, string? parent)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoObservacao = await _db.GetModeloRecursoObservacao(id.Value);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            ViewData["Parent"] = parent;

            return View(modeloRecursoObservacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
        {
            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet.FindAsync(id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoObservacaoSet.Remove(modeloRecursoObservacao);

            await _db.SaveChangesAsync();

            if (parent == "ModeloRecurso")
            {
                return RedirectToAction("Details", "ModeloRecurso", new { id = modeloRecursoObservacao.RecursoId });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
