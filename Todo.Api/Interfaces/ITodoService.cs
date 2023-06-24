namespace Todo.Api.Interfaces
{
    using Todo.Api.Models;

    public interface ITodoService : IGenericService<Todos>
    {
        Task<List<object>> GetTodos(int userId);
    }
}
