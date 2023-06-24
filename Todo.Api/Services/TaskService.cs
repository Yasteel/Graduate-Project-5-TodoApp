using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Api.Interfaces;
using Todo.Api.Models;

namespace Todo.Api.Services
{
    public class TaskService : GenericService<Tasks>, ITaskService
    {
        private readonly ApplicationDbContext context;

        public TaskService(ApplicationDbContext context) 
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<Tasks>> GetTasks(int todoId)
        {
            return await this.context.Set<Tasks>().Where(_ => _.TodoId == todoId).ToListAsync();
        }


    }
}
