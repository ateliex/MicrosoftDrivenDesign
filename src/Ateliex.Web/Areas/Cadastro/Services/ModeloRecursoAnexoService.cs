using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloRecursoAnexoService
    {
        public static async Task<List<ModeloRecursoAnexo>> GetModeloRecursoAnexoAll(this ApplicationDbContext db)
        {
            var list = await db.ModeloRecursoAnexoSet
                .Include(mra => mra.Recurso)
                    .ThenInclude(r => r.Modelo)
                .ToListAsync();

            return list;
        }

        public static async Task<ModeloRecursoAnexo> GetModeloRecursoAnexo(this ApplicationDbContext db, int id)
        {
            var item = await db.ModeloRecursoAnexoSet
                .Include(mra => mra.Recurso)
                    .ThenInclude(r => r.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);

            return item;
        }
    }
}
