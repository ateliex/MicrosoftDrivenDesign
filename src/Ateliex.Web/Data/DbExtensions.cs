using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ateliex.Data
{
    public static class DbExtensions
    {
        //public static async Task<List<TEntity>> ToEntityListAsync<TEntity>(this DbContext db)
        //    where TEntity : Entity
        //{
        //    var list = await db.Set<TEntity>().ToListAsync();

        //    return list;
        //}

        //public static async Task<TEntity?> FirstOrDefaultEntityAsync<TEntity>(this DbContext db, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        //    where TEntity : Entity
        //{
        //    var entity = await db.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);

        //    return entity;
        //}

        //public static async Task<TEntity?> FindEntityAsync<TEntity>(this DbContext db, int id)
        //     where TEntity : Entity
        //{
        //    var entity = await db.Set<TEntity>().FindAsync(id);

        //    return entity;
        //}

        public static bool ExistsEntity<TEntity>(this DbContext db, int id)
            where TEntity : Entity
        {
            return db.Set<TEntity>().Any(e => e.Id == id);
        }

        //public static async Task AddAndSaveChangesAsync<TEntity>(this DbContext db, TEntity entity)
        //    where TEntity : Entity
        //{
        //    db.Set<TEntity>().Add(entity);

        //    await db.SaveChangesAsync();
        //}

        //public static async Task UpdateAndSaveChangesAsync<TEntity>(this DbContext db, TEntity entity)
        //    where TEntity : Entity
        //{
        //    db.Set<TEntity>().Update(entity);

        //    await db.SaveChangesAsync();
        //}

        //public static async Task RemoveAndSaveChangesAsync<TEntity>(this DbContext db, TEntity entity)
        //    where TEntity : Entity
        //{
        //    db.Set<TEntity>().Remove(entity);

        //    await db.SaveChangesAsync();
        //}
    }
}
