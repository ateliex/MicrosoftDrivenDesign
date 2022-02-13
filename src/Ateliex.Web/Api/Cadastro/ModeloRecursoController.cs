using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Ateliex.Api.Cadastro
{
    [Route("api/Cadastro/[controller]")]
    [ApiController]
    [SwaggerTag("Cadastro")]
    public class ModeloRecursoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetModeloRecursoAll")]
        public async Task<ActionResult<IEnumerable<ModeloRecurso>>> GetModeloRecursoAll()
        {
            var list = await _db.GetModeloRecursoAll();

            return list;
        }

        [HttpGet("{id}", Name = "GetModeloRecurso")]
        public async Task<ActionResult<ModeloRecurso>> GetModeloRecurso(int id)
        {
            var modeloRecurso = await _db.GetModeloRecurso(id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            return modeloRecurso;
        }

        [HttpPut("{id}", Name = "PutModeloRecurso")]
        public async Task<IActionResult> PutModeloRecurso(int id, ModeloRecurso modeloRecurso)
        {
            if (id != modeloRecurso.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecurso).State = EntityState.Modified;

            try
            {
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

            return NoContent();
        }

        [HttpPost(Name = "PostModeloRecurso")]
        public async Task<ActionResult<ModeloRecurso>> PostModeloRecurso(ModeloRecurso modeloRecurso)
        {
            _db.ModeloRecursoSet.Add(modeloRecurso);

            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModeloRecurso", new { id = modeloRecurso.Id }, modeloRecurso);
        }

        [HttpDelete(Name = "DeleteModeloRecurso")]
        [ApiConventionMethod(typeof(AteliexApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> DeleteModeloRecurso(int id)
        {
            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoSet.Remove(modeloRecurso);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
