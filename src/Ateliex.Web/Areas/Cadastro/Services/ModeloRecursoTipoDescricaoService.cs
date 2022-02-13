using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloRecursoTipoDescricaoService
    {
        public static async Task<List<ModeloRecursoTipoDescricao>> GetModeloRecursoTipoDescricaoAll(this ApplicationDbContext db)
        {
            var list = await db.ModeloRecursoTipoDescricaoSet
                .Include(mrtd => mrtd.Tipo)
                .ToListAsync();

            return list;
        }

        public static async Task<ModeloRecursoTipoDescricao> GetModeloRecursoTipoDescricao(this ApplicationDbContext db, int id)
        {
            var item = await db.ModeloRecursoTipoDescricaoSet
                .Include(mrtd => mrtd.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            return item;
        }
    }
}
