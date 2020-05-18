using Snowman.Tourism.Domain;
using System.Threading.Tasks;

namespace Snowman.Tourism.Repository
{
    public interface ITourismRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //CATEGORIES
        Task<Category[]> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsyncById(int categoryId);

        //SPOTS
        Task<Spot[]> GetAllSpotsAsync();
        Task<Spot> GetSpotAsyncById(int spotId, bool includeChildren);
        Task<Spot[]> GetSpotAsyncByUserRegistered(int userId);
        Task<Spot[]> GetAllSpotsAsyncByName(string name, bool includeChildren);

    }
}
