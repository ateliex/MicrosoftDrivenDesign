using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Api.Cadastro
{
    [Route("api/Cadastro/[controller]")]
    [ApiController]
    public class ModeloRecursoObservacaoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoObservacaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetModeloRecursoObservacaoAll")]
        public async Task<ActionResult<IEnumerable<ModeloRecursoObservacao>>> GetModeloRecursoObservacaoAll()
        {
            var list = await _db.GetModeloRecursoObservacaoAll();

            return list;
        }

        [HttpGet("{id}", Name = "GetModeloRecursoObservacao")]
        public async Task<ActionResult<ModeloRecursoObservacao>> GetModeloRecursoObservacao(int id)
        {
            var modeloRecursoObservacao = await _db.GetModeloRecursoObservacao(id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            return modeloRecursoObservacao;
        }

        [HttpPut("{id}", Name = "PutModeloRecursoObservacao")]
        public async Task<IActionResult> PutModeloRecursoObservacao(int id, ModeloRecursoObservacao modeloRecursoObservacao)
        {
            if (id != modeloRecursoObservacao.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecursoObservacao).State = EntityState.Modified;

            try
            {
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

            return NoContent();
        }

        [HttpPost(Name = "PostModeloRecursoObservacao")]
        public async Task<ActionResult<ModeloRecursoObservacao>> PostModeloRecursoObservacao(ModeloRecursoObservacao modeloRecursoObservacao)
        {
            _db.ModeloRecursoObservacaoSet.Add(modeloRecursoObservacao);

            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModeloRecursoObservacao", new { id = modeloRecursoObservacao.Id }, modeloRecursoObservacao);
        }

        [HttpDelete(Name = "DeleteModeloRecursoObservacao")]
        [ApiConventionMethod(typeof(AteliexApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> DeleteModeloRecursoObservacao(int id)
        {
            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet.FindAsync(id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoObservacaoSet.Remove(modeloRecursoObservacao);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
