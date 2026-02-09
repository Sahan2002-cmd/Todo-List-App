using TodoListAPI.Models;
using TodoListAPI.Models.DTOs;

namespace TodoListAPI.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem?> GetTodoByIdAsync(int id);
        Task<TodoItem> CreateTodoAsync(CreateTodoDto createTodoDto);
        Task<TodoItem?> UpdateTodoAsync(int id, UpdateTodoDto updateTodoDto);
        Task<bool> DeleteTodoAsync(int id);
        Task<IEnumerable<TodoItem>> GetTodosByStatusAsync(bool isCompleted);
    }
}