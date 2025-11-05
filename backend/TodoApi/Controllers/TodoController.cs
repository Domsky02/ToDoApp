using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        ApiDbContext _context;
        public TodoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllTasks()
        {
            var toDoItemsList = await _context.TodoItems.ToArrayAsync();
            return Ok(toDoItemsList);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewTask([FromBody] ToDoItem taskToAdd)
        {
            _context.TodoItems.Add(taskToAdd);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditTaskStatus(int id)
        {
            var findTask = await _context.TodoItems.FindAsync(id);
            if (findTask == null) {
                return NotFound();
            } else { 
                findTask.CzyZrobione = !findTask.CzyZrobione;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
