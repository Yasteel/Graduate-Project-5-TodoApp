using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Todo.Api.Interfaces;
using Todo.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITodoService todoService;
        private readonly ITaskService taskService;

        public TasksController
        (
            ITodoService todoService,
            ITaskService taskService
        )
        {
            this.todoService = todoService;
            this.taskService = taskService;
        }



        // GET: api/<TasksController>
        [HttpGet("{todoId}")]
        public async Task<string> Get(int todoId)
        {
            return JsonConvert.SerializeObject(await this.taskService.GetTasks(todoId));
        }

        // POST api/<TasksController>
        [HttpPost("{todoId}")]
        public void Post(int todoId, [FromBody] string value)
        {
            var taskEntity = JsonConvert.DeserializeObject<Tasks>(value);
            this.taskService.Add(taskEntity);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var taskEntity = JsonConvert.DeserializeObject<Tasks>(value);
            this.taskService.Update(taskEntity);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.taskService.Delete(id);
        }
    }
}
