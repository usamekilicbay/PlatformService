using PlatformService.Models;
using System.Linq.Expressions;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        Task Add(Platform platform);
        Task AddRange(IEnumerable<Platform> platforms);

        Task<Platform> Get(int id);
        Task<IEnumerable<Platform>> GetAll();
        Task<IEnumerable<Platform>> Find(Expression<Func<Platform, bool>> predicate);

        void Remove(Platform platform);
        void RemoveRange(IEnumerable<Platform> platforms);

        Task<bool> SaveChanges();
    }
}
