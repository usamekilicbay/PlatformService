using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using System;
using System.Linq.Expressions;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository, IDisposable
    {
        public PlatformRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private readonly AppDbContext _appDbContext;

        public async Task Add(Platform platform)
        {
            ArgumentNullException.ThrowIfNull(nameof(platform));

            await _appDbContext.AddAsync(platform);
        }

        public async Task AddRange(IEnumerable<Platform> platforms)
        {
            if (!platforms.Any())
                throw new ArgumentNullException(nameof(platforms));

            await _appDbContext.AddRangeAsync(platforms);
        }

        public async Task<Platform> Get(int id)
        {
            return await _appDbContext.Platforms.FindAsync(id);
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            return await _appDbContext.Platforms.ToListAsync();
        }

        public async Task<IEnumerable<Platform>> Find(Expression<Func<Platform, bool>> predicate)
        {
            return await _appDbContext.Platforms.Where(predicate).ToListAsync();
        }

        public void Remove(Platform platform)
        {
            _appDbContext.Remove(platform);
        }

        public void RemoveRange(IEnumerable<Platform> platforms)
        {
            _appDbContext.RemoveRange(platforms);
        }

        public async Task<bool> SaveChanges()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
