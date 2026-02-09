using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Models;
using TodoListAPI.Repositories.Interfaces;

namespace TodoListAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            todoItem.CreatedAt = DateTime.UtcNow;
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<TodoItem?> UpdateAsync(int id, TodoItem todoItem)
        {
            var existingTodo = await _context.TodoItems.FindAsync(id);
            if (existingTodo == null)
                return null;

            existingTodo.Title = todoItem.Title;
            existingTodo.Description = todoItem.Description;
            existingTodo.IsCompleted = todoItem.IsCompleted;

            if (todoItem.IsCompleted && !existingTodo.IsCompleted)
            {
                existingTodo.CompletedAt = DateTime.UtcNow;
            }
            else if (!todoItem.IsCompleted)
            {
                existingTodo.CompletedAt = null;
            }

            await _context.SaveChangesAsync();
            return existingTodo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return false;

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TodoItem>> GetByStatusAsync(bool isCompleted)
        {
            return await _context.TodoItems
                .Where(t => t.IsCompleted == isCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
    }
}