import axios from 'axios';

const API_URL = 'http://localhost:5253/api/todo';

export const todoService = {
    // Get all todos
    getAllTodos: async () => {
        const response = await axios.get(API_URL);
        return response.data;
    },

    // Get todo by ID
    getTodoById: async (id) => {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    },

    // Create new todo
    createTodo: async (todoData) => {
        const response = await axios.post(API_URL, todoData);
        return response.data;
    },

    // Update todo
    updateTodo: async (id, todoData) => {
        const response = await axios.put(`${API_URL}/${id}`, todoData);
        return response.data;
    },

    // Delete todo
    deleteTodo: async (id) => {
        await axios.delete(`${API_URL}/${id}`);
    },

    // Get todos by status
    getTodosByStatus: async (isCompleted) => {
        const response = await axios.get(`${API_URL}?isCompleted=${isCompleted}`);
        return response.data;
    }
};
