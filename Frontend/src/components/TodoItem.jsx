import React, { useState } from 'react';
import { FaTrash, FaEdit, FaCheck, FaTimes } from 'react-icons/fa';
import '../styles/TodoItem.css';

const TodoItem = ({ todo, onUpdate, onDelete }) => {
    const [isEditing, setIsEditing] = useState(false);
    const [editTitle, setEditTitle] = useState(todo.title);
    const [editDescription, setEditDescription] = useState(todo.description || '\'');

    const handleToggleComplete = () => {
        onUpdate(todo.id, { isCompleted: !todo.isCompleted });
    };

    const handleEdit = () => {
        setIsEditing(true);
    };

    const handleSave = () => {
        onUpdate(todo.id, { 
            title: editTitle, 
            description: editDescription 
        });
        setIsEditing(false);
    };

    const handleCancel = () => {
        setEditTitle(todo.title);
        setEditDescription(todo.description || '\'');
        setIsEditing(false);
    };

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        return date.toLocaleDateString() + ' ' + date.toLocaleTimeString();
    };

    return (
        <div className={`todo-item ${todo.isCompleted ? 'completed' : '\''}`}>
            {isEditing ? (
                <div className="todo-edit">
                    <input
                        type="text"
                        value={editTitle}
                        onChange={(e) => setEditTitle(e.target.value)}
                        className="edit-input"
                    />
                    <textarea
                        value={editDescription}
                        onChange={(e) => setEditDescription(e.target.value)}
                        className="edit-textarea"
                        rows="2"
                    />
                    <div className="edit-actions">
                        <button onClick={handleSave} className="btn-save">
                            <FaCheck /> Save
                        </button>
                        <button onClick={handleCancel} className="btn-cancel">
                            <FaTimes /> Cancel
                        </button>
                    </div>
                </div>
            ) : (
                <>
                    <div className="todo-content">
                        <div className="todo-header">
                            <input
                                type="checkbox"
                                checked={todo.isCompleted}
                                onChange={handleToggleComplete}
                                className="todo-checkbox"
                            />
                            <h3 className="todo-title">{todo.title}</h3>
                        </div>
                        {todo.description && (
                            <p className="todo-description">{todo.description}</p>
                        )}
                        <div className="todo-meta">
                            <span className="todo-date">
                                Created: {formatDate(todo.createdAt)}
                            </span>
                            {todo.completedAt && (
                                <span className="todo-date completed-date">
                                    Completed: {formatDate(todo.completedAt)}
                                </span>
                            )}
                        </div>
                    </div>
                    <div className="todo-actions">
                        <button onClick={handleEdit} className="btn-edit">
                            <FaEdit />
                        </button>
                        <button onClick={() => onDelete(todo.id)} className="btn-delete">
                            <FaTrash />
                        </button>
                    </div>
                </>
            )}
        </div>
    );
};

export default TodoItem;
