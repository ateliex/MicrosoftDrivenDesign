using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Api.Cadastro
{
    [Route("api/Cadastro/[controller]")]
    [ApiController]
    public class ModeloRecursoAnexoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoAnexoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetModeloRecursoAnexoAll")]
        public async Task<ActionResult<IEnumerable<ModeloRecursoAnexo>>> GetModeloRecursoAnexoAll()
        {
            var list = await _db.GetModeloRecursoAnexoAll();

            return list;
        }

        [HttpGet("{id}", Name = "GetModeloRecursoAnexo")]
        public async Task<ActionResult<ModeloRecursoAnexo>> GetModeloRecursoAnexo(int id)
        {
            var modeloRecursoAnexo = await _db.GetModeloRecursoAnexo(id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            return modeloRecursoAnexo;
        }

        [HttpPut("{id}", Name = "PutModeloRecursoAnexo")]
        public async Task<IActionResult> PutModeloRecursoAnexo(int id, ModeloRecursoAnexo modeloRecursoAnexo)
        {
            if (id != modeloRecursoAnexo.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecursoAnexo).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ExistsEntity<ModeloRecursoAnexo>(modeloRecursoAnexo.Id))
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

        [HttpPost(Name = "PostModeloRecursoAnexo")]
        public async Task<ActionResult<ModeloRecursoAnexo>> PostModeloRecursoAnexo(ModeloRecursoAnexo modeloRecursoAnexo)
        {
            _db.ModeloRecursoAnexoSet.Add(modeloRecursoAnexo);

            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModeloRecursoAnexo", new { id = modeloRecursoAnexo.Id }, modeloRecursoAnexo);
        }

        [HttpDelete(Name = "DeleteModeloRecursoAnexo")]
        [ApiConventionMethod(typeof(AteliexApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> DeleteModeloRecursoAnexo(int id)
        {
            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet.FindAsync(id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoAnexoSet.Remove(modeloRecursoAnexo);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
