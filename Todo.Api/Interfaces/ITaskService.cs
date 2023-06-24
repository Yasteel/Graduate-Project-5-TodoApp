namespace Todo.Api.Interfaces
{
    using Todo.Api.Models;

    public interface ITaskService : IGenericService<Tasks>
    {
        Task<List<Tasks>> GetTasks(int todoId);

        //void CreateTask(Task task);

        //void UpdateTask(Task task);

        //void DeleteTask(int taskId);
    }
}
