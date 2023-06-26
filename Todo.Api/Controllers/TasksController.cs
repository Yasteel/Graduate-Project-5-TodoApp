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
        [HttpPost]
        public void Post([FromBody] Tasks value)
        {
            value.CreatedDate = DateTime.Now;
            this.taskService.Add(value);
        }

        // PUT api/<TasksController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] Tasks value)
        {
            var taskEdit = this.taskService.GetById(id);

            if (value.Status is not null && value.Status.Length > 0)
            {
                taskEdit.Status = value.Status;
            }

            if(value.Description is not null && value.Description.Length > 0)
            {
                taskEdit.Description = value.Description;
            }


            this.taskService.Update(taskEdit);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.taskService.Delete(id);
        }
    }
}
