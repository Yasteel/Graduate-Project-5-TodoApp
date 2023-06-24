namespace Todo.Api.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Todo.Api.Data;
    using Todo.Api.Interfaces;
    using Todo.Api.Models;

    public class TodoService : GenericService<Todos>, ITodoService
    {
        private readonly ApplicationDbContext context;
        private readonly ITaskService taskService;

        public TodoService
            (
                ApplicationDbContext context,
                ITaskService taskService
            ) 
            : base(context)
        {
            this.context = context;
            this.taskService = taskService;
        }

        public async Task<List<object>> GetTodos(int userId)
        {
            var todos = await this.context.Set<Todos>().Where(_ => _.UserId == userId).ToListAsync<Todos>();

            var objectList = new List<object>();

            if(todos.Count > 0)
            {
                foreach (var todo in todos)
                {
                    objectList.Add(new
                    {
                        Todo = todo,
                        Tasks = await this.taskService.GetTasks(todo.Id)
                    });
                }

                return objectList;
            }
            else
            {
                return new ();
            }
        }
    }
}
