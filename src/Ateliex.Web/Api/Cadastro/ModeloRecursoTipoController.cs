using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Ateliex.Api.Cadastro
{
    [Route("api/Cadastro/[controller]")]
    [ApiController]
    [SwaggerTag("Cadastro")]
    public class ModeloRecursoTipoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoTipoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetModeloRecursoTipoAll")]
        public async Task<ActionResult<IEnumerable<ModeloRecursoTipo>>> GetModeloRecursoTipoAll()
        {
            var list = await _db.GetModeloRecursoTipoAll();

            return list;
        }

        [HttpGet("{id}", Name = "GetModeloRecursoTipo")]
        public async Task<ActionResult<ModeloRecursoTipo>> GetModeloRecursoTipo(int id)
        {
            ModeloRecursoTipo modeloRecursoTipo = await _db.GetModeloRecursoTipo(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return modeloRecursoTipo;
        }

        [HttpPut("{id}", Name = "PutModeloRecursoTipo")]
        public async Task<IActionResult> PutModeloRecursoTipo(int id, ModeloRecursoTipo modeloRecursoTipo)
        {
            if (id != modeloRecursoTipo.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecursoTipo).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ExistsEntity<ModeloRecursoTipo>(modeloRecursoTipo.Id))
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

        [HttpPost(Name = "PostModeloRecursoTipo")]
        public async Task<ActionResult<ModeloRecursoTipo>> PostModeloRecursoTipo(ModeloRecursoTipo modeloRecursoTipo)
        {
            _db.ModeloRecursoTipoSet.Add(modeloRecursoTipo);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!_db.ExistsEntity<ModeloRecursoTipo>(modeloRecursoTipo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModeloRecursoTipo", new { id = modeloRecursoTipo.Id }, modeloRecursoTipo);
        }

        [HttpDelete(Name = "DeleteModeloRecursoTipo")]
        [ApiConventionMethod(typeof(AteliexApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> DeleteModeloRecursoTipo(int id)
        {
            var modeloRecursoTipo = await _db.ModeloRecursoTipoSet.FindAsync(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoTipoSet.Remove(modeloRecursoTipo);

            try
            {
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException)
                {
                    var sqlException = ex.InnerException as SqlException;

                    if (sqlException.Message.Contains("FK_ModeloRecurso_ModeloRecursoTipo_TipoId"))
                    {
                        var problemDetails = new ProblemDetails
                        {
                            Title = ex.Message,
                            Detail = sqlException.Message
                        };

                        return BadRequest(problemDetails);
                    }
                }

                throw;
            }
        }
    }
}
