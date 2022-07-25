using System;
using Microsoft.EntityFrameworkCore;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;

namespace NTG.ShipmentManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShipmentRequestDbContext dbContext;

        public GenericRepository(ShipmentRequestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T?> GetAsync(int id)
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.dbContext.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            this.dbContext.Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await this.GetAsync(id);
            return entity != null;
        }

        public async Task<int> SaveAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}

