using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Api.Cadastro
{
    [Route("api/Cadastro/[controller]")]
    [ApiController]
    public class ModeloRecursoTipoDescricaoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoTipoDescricaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetModeloRecursoTipoDescricaoAll")]
        public async Task<ActionResult<IEnumerable<ModeloRecursoTipoDescricao>>> GetModeloRecursoTipoDescricaoAll()
        {
            var list = await _db.GetModeloRecursoTipoDescricaoAll();

            return list;
        }

        [HttpGet("{id}", Name = "GetModeloRecursoTipoDescricao")]
        public async Task<ActionResult<ModeloRecursoTipoDescricao>> GetModeloRecursoTipoDescricao(int id)
        {
            ModeloRecursoTipoDescricao modeloRecursoTipoDescricao = await _db.GetModeloRecursoTipoDescricao(id);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            return modeloRecursoTipoDescricao;
        }

        [HttpPut("{id}", Name = "PutModeloRecursoTipoDescricao")]
        public async Task<IActionResult> PutModeloRecursoTipoDescricao(int id, ModeloRecursoTipoDescricao modeloRecursoTipoDescricao)
        {
            if (id != modeloRecursoTipoDescricao.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecursoTipoDescricao).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloRecursoTipoDescricaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost(Name = "PostModeloRecursoTipoDescricao")]
        public async Task<ActionResult<ModeloRecursoTipoDescricao>> PostModeloRecursoTipoDescricao(ModeloRecursoTipoDescricao modeloRecursoTipoDescricao)
        {
            _db.ModeloRecursoTipoDescricaoSet.Add(modeloRecursoTipoDescricao);

            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModeloRecursoTipoDescricao", new { id = modeloRecursoTipoDescricao.Id }, modeloRecursoTipoDescricao);
        }

        // DELETE: api/ModeloRecursoTipoDescricao/5
        [HttpDelete(Name = "DeleteModeloRecursoTipoDescricao")]
        [ApiConventionMethod(typeof(AteliexApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> DeleteModeloRecursoTipoDescricao(int id)
        {
            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDescricaoSet.FindAsync(id);
            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoTipoDescricaoSet.Remove(modeloRecursoTipoDescricao);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloRecursoTipoDescricaoExists(int id)
        {
            return _db.ModeloRecursoTipoDescricaoSet.Any(e => e.Id == id);
        }
    }
}
