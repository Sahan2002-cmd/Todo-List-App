import React from 'react';
import '../styles/TodoFilter.css';

const TodoFilter = ({ currentFilter, onFilterChange }) => {
    return (
        <div className="todo-filter">
            <button
                className={`filter-btn ${currentFilter === 'all' ? 'active' : '\''}`}
                onClick={() => onFilterChange('all')}
            >
                All
            </button>
            <button
                className={`filter-btn ${currentFilter === 'active' ? 'active' : '\''}`}
                onClick={() => onFilterChange('active')}
            >
                Active
            </button>
            <button
                className={`filter-btn ${currentFilter === 'completed' ? 'active' : '\''}`}
                onClick={() => onFilterChange('completed')}
            >
                Completed
            </button>
        </div>
    );
};

export default TodoFilter;
