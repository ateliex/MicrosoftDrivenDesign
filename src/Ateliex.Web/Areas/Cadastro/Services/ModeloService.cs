using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloService
    {
        public static async Task<List<Modelo>> GetModeloAll(this ApplicationDbContext db)
        {
            var list = await db.ModeloSet
                .Include(m => m.Recursos)
                .ToListAsync();

            return list;
        }

        public static async Task<Modelo> GetModelo(this ApplicationDbContext db, int id)
        {
            var item = await db.ModeloSet
                .Include(m => m.Recursos)
                .ThenInclude(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            return item;
        }
    }
}
