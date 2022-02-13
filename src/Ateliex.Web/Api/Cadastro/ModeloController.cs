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
    public class ModeloController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Modelo
        [HttpGet(Name = "GetModeloAll")]
        public async Task<IEnumerable<Modelo>> GetModeloAll()
        {
            var list = await _db.GetModeloAll();

            return list;
        }

        // GET: api/Modelo/5
        [HttpGet("{id}", Name = "GetModelo")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            var modelo = await _db.GetModelo(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/Modelo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = "PutModelo")]
        public async Task<IActionResult> PutModelo(int id, Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }

            _db.Entry(modelo).State = EntityState.Modified;

            try
            {
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

            return NoContent();
        }

        // POST: api/Modelo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "PostModelo")]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
        {
            _db.ModeloSet.Add(modelo);

            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModelo", new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modelo/5
        [HttpDelete("{id}", Name = "DeleteModelo")]
        [ApiConventionMethod(typeof(AteliexApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _db.ModeloSet.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            _db.ModeloSet.Remove(modelo);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
