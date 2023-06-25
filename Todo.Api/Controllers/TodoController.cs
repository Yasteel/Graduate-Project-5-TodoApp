using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Todo.Api.Interfaces;
using Todo.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;
        private readonly ITaskService taskService;

        public TodoController
            (
                ITodoService todoService,
                ITaskService taskService
            )
        {
            this.todoService = todoService;
            this.taskService = taskService;
        }

        // GET: api/<TodoController>
        [HttpGet("{userId}")]
        public async Task<string> Get(int userId)
        {
            return JsonConvert.SerializeObject(await this.todoService.GetTodos(userId));
        }

        // POST api/<TodoController>
        [HttpPost("{userId}")]
        public void Post(int userId, [FromBody] Todos value)
        {
            this.todoService.Add(value);
        }

        // PUT api/<TodoController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] Todos value)
        {
            var todoEdit = this.todoService.GetById(id);
            todoEdit.Description = value.Description;
            this.todoService.Update(todoEdit);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.todoService.Delete(id);
        }
    }
}
