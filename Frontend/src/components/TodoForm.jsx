import React, { useState } from 'react';
import '../styles/TodoForm.css';

const TodoForm = ({ onAdd }) => {
    const [title, setTitle] = useState('\'');
    const [description, setDescription] = useState('\'');
    const [error, setError] = useState('\'');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        if (!title.trim()) {
            setError('Title is required');
            return;
        }

        onAdd({ title, description });
        setTitle('\'');
        setDescription('\'');
        setError('\'');
    };

    return (
        <div className="todo-form-container">
            <h2>Add New Todo</h2>
            <form onSubmit={handleSubmit} className="todo-form">
                <div className="form-group">
                    <input
                        type="text"
                        placeholder="Enter todo title..."
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        className="form-input"
                    />
                </div>
                <div className="form-group">
                    <textarea
                        placeholder="Enter description (optional)..."
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        className="form-textarea"
                        rows="3"
                    />
                </div>
                {error && <div className="error-message">{error}</div>}
                <button type="submit" className="btn-add">
                    Add Todo
                </button>
            </form>
        </div>
    );
};

export default TodoForm;
