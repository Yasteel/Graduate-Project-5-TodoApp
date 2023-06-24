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
        [HttpGet]
        public async Task<string> Get()
        {
            return JsonConvert.SerializeObject(await this.todoService.GetTodos(1));
        }

        // GET: api/Todo/{todoId}/task
        // Gets all tasks related to Todo item
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return JsonConvert.SerializeObject(await this.todoService.GetById(id));
        }

        // POST api/<TodoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var todoEntity = JsonConvert.DeserializeObject<Todos>(value);
            this.todoService.Add(todoEntity);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var todoEntity = JsonConvert.DeserializeObject<Todos>(value);
            this.todoService.Update(todoEntity);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.todoService.Delete(id);
        }
    }
}
