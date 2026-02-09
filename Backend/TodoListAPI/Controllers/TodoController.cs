using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models.DTOs;
using TodoListAPI.Services.Interfaces;

namespace TodoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isCompleted)
        {
            if (isCompleted.HasValue)
            {
                var filteredTodos = await _todoService.GetTodosByStatusAsync(isCompleted.Value);
                return Ok(filteredTodos);
            }

            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
                return NotFound(new { message = $"Todo with ID {id} not found" });

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDto createTodoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTodo = await _todoService.CreateTodoAsync(createTodoDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoDto updateTodoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTodo = await _todoService.UpdateTodoAsync(id, updateTodoDto);
            if (updatedTodo == null)
                return NotFound(new { message = $"Todo with ID {id} not found" });

            return Ok(updatedTodo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todoService.DeleteTodoAsync(id);
            if (!result)
                return NotFound(new { message = $"Todo with ID {id} not found" });

            return NoContent();
        }
    }
}
