using Microsoft.EntityFrameworkCore;
using Snowman.Tourism.Domain;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snowman.Tourism.Repository
{
    public class TourismRepository : ITourismRepository
    {
        private readonly TourismContext _context;

        public TourismRepository(TourismContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        #region Categories

        public async Task<Category[]> GetAllCategoriesAsync()
        {
            return await _context.Categories.OrderBy(c => c.Id).ToArrayAsync();
        }

        public async Task<Category> GetCategoryAsyncById(int categoryId)
        {
            IQueryable<Category> query = _context.Categories
                            .Include(c => c.Spots)
                            .OrderBy(c => c.Id)
                            .Where(c => c.Id == categoryId);

            return await query.FirstOrDefaultAsync();
        }
        #endregion

        #region Spots
        public async Task<Spot[]> GetAllSpotsAsync()
        {
            return await _context.Spots.OrderBy(s => s.Id).ToArrayAsync();
        }

        public async Task<Spot> GetSpotAsyncById(int spotId, bool includeChildren = false)
        {
            IQueryable<Spot> query = _context.Spots
                                        .Include(s => s.Category);

            if (includeChildren)
            {
                query = query
                        .Include(s => s.Comments)
                        .Include(s => s.Pictures);
            }

            query = query.OrderBy(s => s.Id)
                        .Where(s => s.Id == spotId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Spot[]> GetSpotAsyncByUserRegistered(int userId)
        {
            return await _context.Spots
                            .Include(s => s.Category)
                            .OrderBy(s => s.Id)
                            .Where(s => s.UserId == userId)
                            .ToArrayAsync();
        }

        public async Task<Spot[]> GetAllSpotsAsyncByName(string name, bool includeChildren = false)
        {
            IQueryable<Spot> query = _context.Spots
                                        .Include(s => s.Category);

            if (includeChildren)
            {
                query = query
                        .Include(s => s.Comments)
                        .Include(s => s.Pictures);
            }

            query = query.OrderBy(s => s.Id)
                        .Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        #endregion
    }
}
