using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloRecursoObservacaoService
    {
        public static async Task<List<ModeloRecursoObservacao>> GetModeloRecursoObservacaoAll(this ApplicationDbContext db)
        {
            var list = await db.ModeloRecursoObservacaoSet
                .Include(mro => mro.Recurso)
                .ThenInclude(mr => mr.Modelo)
                .ToListAsync();

            return list;
        }

        public static async Task<ModeloRecursoObservacao> GetModeloRecursoObservacao(this ApplicationDbContext db, int id)
        {
            var item = await db.ModeloRecursoObservacaoSet
                .Include(mro => mro.Recurso)
                .ThenInclude(mr => mr.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);

            return item;
        }
    }
}
