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

        public T GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            T? entity = this.context.Set<T>().Find(id);
            this.context.Set<T>().Remove(entity!);
            this.context.SaveChanges();
        }
    }
}
