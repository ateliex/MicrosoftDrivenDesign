using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    public abstract class DefaultController<TEntity> : Controller
        where TEntity : Entity
    {
        private readonly ApplicationDbContext _db;

        public DefaultController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: TEntity
        public async Task<IActionResult> Index()
        {
            return View(await _db.Set<TEntity>().ToListAsync());
        }

        // GET: TEntity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _db.Set<TEntity>().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: TEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                _db.Add(entity);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // GET: TEntity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _db.Set<TEntity>().FindAsync(id.Value);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: TEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(entity);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.ExistsEntity<TEntity>(entity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // GET: TEntity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _db.Set<TEntity>().FindAsync(id.Value);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: TEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _db.Set<TEntity>().Remove(entity);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
