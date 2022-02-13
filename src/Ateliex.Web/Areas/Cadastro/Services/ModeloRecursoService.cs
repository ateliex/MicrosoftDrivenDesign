using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloRecursoService
    {
        public static async Task<List<ModeloRecurso>> GetModeloRecursoAll(this ApplicationDbContext db)
        {
            var list = await db.ModeloRecursoSet
                .Include(r => r.Modelo)
                .Include(r => r.Tipo)
                .ToListAsync();

            return list;
        }

        public static async Task<ModeloRecurso> GetModeloRecurso(this ApplicationDbContext db, int id)
        {
            var item = await db.ModeloRecursoSet
                .Include(r => r.Modelo)
                .Include(r => r.Observacao)
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            return item;
        }
    }
}
