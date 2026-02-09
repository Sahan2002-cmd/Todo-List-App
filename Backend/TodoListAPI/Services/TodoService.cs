using TodoListAPI.Models;
using TodoListAPI.Models.DTOs;
using TodoListAPI.Repositories.Interfaces;
using TodoListAPI.Services.Interfaces;

namespace TodoListAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<TodoItem?> GetTodoByIdAsync(int id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<TodoItem> CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            var todoItem = new TodoItem
            {
                Title = createTodoDto.Title,
                Description = createTodoDto.Description,
                IsCompleted = false
            };

            return await _todoRepository.CreateAsync(todoItem);
        }

        public async Task<TodoItem?> UpdateTodoAsync(int id, UpdateTodoDto updateTodoDto)
        {
            var existingTodo = await _todoRepository.GetByIdAsync(id);
            if (existingTodo == null)
                return null;

            if (!string.IsNullOrEmpty(updateTodoDto.Title))
                existingTodo.Title = updateTodoDto.Title;

            if (updateTodoDto.Description != null)
                existingTodo.Description = updateTodoDto.Description;

            if (updateTodoDto.IsCompleted.HasValue)
                existingTodo.IsCompleted = updateTodoDto.IsCompleted.Value;

            return await _todoRepository.UpdateAsync(id, existingTodo);
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            return await _todoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetTodosByStatusAsync(bool isCompleted)
        {
            return await _todoRepository.GetByStatusAsync(isCompleted);
        }
    }
}
