using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Api.Interfaces;

namespace Todo.Api.Services
{
    public class GenericService<T> : IGenericService<T>
        where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async void Add(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            T? entity = await this.context.Set<T>().FindAsync(id);
            this.context.Set<T>().Remove(entity!);
            await this.context.SaveChangesAsync();
        }
    }
}
