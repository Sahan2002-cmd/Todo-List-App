# 📝 Todo List Application

A full-stack Todo List application built with **ASP.NET Core** backend and **React** frontend.

## 🚀 Features

- ✅ Create, Read, Update, Delete (CRUD) todos
- ✅ Mark todos as completed/active
- ✅ Filter todos by status (All, Active, Completed)
- ✅ Edit todos inline
- ✅ Responsive and modern UI
- ✅ Real-time statistics (Total, Active, Completed)
- ✅ RESTful API architecture
- ✅ Repository and Service pattern implementation

## 🛠️ Tech Stack

### Backend
- **ASP.NET Core 10.0** - Web API
- **Entity Framework Core** - ORM
- **SQLite** - Database
- **Swagger/OpenAPI** - API Documentation

### Frontend
- **React 18** - UI Library
- **Axios** - HTTP Client
- **React Icons** - Icons
- **CSS3** - Styling

## 📁 Project Structure
```
Todo List App/
│
├── Backend/
│   └── TodoListAPI/
│       ├── Controllers/
│       │   └── TodoController.cs
│       ├── Models/
│       │   ├── DTOs/
│       │   │   ├── CreateTodoDto.cs
│       │   │   └── UpdateTodoDto.cs
│       │   └── TodoItem.cs
│       ├── Data/
│       │   └── TodoDbContext.cs
│       ├── Services/
│       │   ├── Interfaces/
│       │   │   └── ITodoService.cs
│       │   └── TodoService.cs
│       ├── Repositories/
│       │   ├── Interfaces/
│       │   │   └── ITodoRepository.cs
│       │   └── TodoRepository.cs
│       ├── Program.cs
│       ├── appsettings.json
│       └── todolist.db
│
└── Frontend/ (or C:\temp\mytodoapp)
    ├── src/
    │   ├── components/
    │   │   ├── TodoForm.jsx
    │   │   ├── TodoItem.jsx
    │   │   ├── TodoList.jsx
    │   │   └── TodoFilter.jsx
    │   ├── services/
    │   │   └── todoService.js
    │   ├── hooks/
    │   │   └── useTodos.js
    │   ├── styles/
    │   │   ├── App.css
    │   │   ├── TodoForm.css
    │   │   ├── TodoItem.css
    │   │   ├── TodoList.css
    │   │   └── TodoFilter.css
    │   ├── App.js
    │   └── index.js
    └── package.json
```

## 🔧 Prerequisites

Before running this project, make sure you have:

- **.NET SDK 10.0** or higher - [Download](https://dotnet.microsoft.com/download)
- **Node.js 18+** and **npm** - [Download](https://nodejs.org/)
- **Git** (optional) - [Download](https://git-scm.com/)

## 📥 Installation & Setup

### 1️⃣ Clone the Repository (Optional)
```bash
git clone <your-repo-url>
cd "Todo List App"
```

### 2️⃣ Backend Setup
```powershell
# Navigate to backend directory
cd Backend/TodoListAPI

# Install dependencies (NuGet packages)
dotnet restore

# Create database migration
dotnet ef migrations add InitialCreate

# Apply migration to create database
dotnet ef database update

# Run the backend
dotnet run
```

Backend will run at: **http://localhost:5253**

Swagger UI: **http://localhost:5253/swagger**

### 3️⃣ Frontend Setup
```powershell
# Navigate to frontend directory
cd C:\temp\mytodoapp
# OR if moved to project folder:
# cd Frontend

# Install dependencies
npm install

# Run the frontend
npm start
```

Frontend will run at: **http://localhost:3000**

## 🎮 Usage

1. **Start the Backend:**
```powershell
   cd Backend/TodoListAPI
   dotnet run
```

2. **Start the Frontend (in a new terminal):**
```powershell
   cd C:\temp\mytodoapp
   npm start
```

3. **Open your browser** and navigate to `http://localhost:3000`

4. **Start managing your todos!**
   - Add new todos with title and description
   - Mark todos as complete by clicking the checkbox
   - Edit todos by clicking the edit icon
   - Delete todos by clicking the trash icon
   - Filter todos by All/Active/Completed

## 🌐 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/todo` | Get all todos |
| GET | `/api/todo/{id}` | Get todo by ID |
| GET | `/api/todo?isCompleted=true` | Get completed todos |
| GET | `/api/todo?isCompleted=false` | Get active todos |
| POST | `/api/todo` | Create new todo |
| PUT | `/api/todo/{id}` | Update todo |
| DELETE | `/api/todo/{id}` | Delete todo |

### Example API Requests

**Create Todo:**
```json
POST /api/todo
{
  "title": "Learn ASP.NET Core",
  "description": "Complete the tutorial"
}
```

**Update Todo:**
```json
PUT /api/todo/1
{
  "title": "Updated title",
  "isCompleted": true
}
```

## 🏗️ Architecture

### Backend Architecture

- **Controller Layer**: Handles HTTP requests and responses
- **Service Layer**: Contains business logic
- **Repository Layer**: Handles data access
- **Model/DTO Layer**: Defines data structures

### Frontend Architecture

- **Components**: Reusable UI components
- **Services**: API communication layer
- **Hooks**: Custom React hooks for state management
- **Styles**: Component-specific CSS files

## 🔐 CORS Configuration

The backend is configured to allow requests from:
- `http://localhost:3000` (Create React App)
- `http://localhost:5173` (Vite)

## 📦 Dependencies

### Backend
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
```

### Frontend
```json
{
  "axios": "^1.x.x",
  "react": "^18.x.x",
  "react-dom": "^18.x.x",
  "react-icons": "^4.x.x"
}
```

## 🐛 Troubleshooting

### Backend won't start
```powershell
# Rebuild the project
dotnet clean
dotnet build

# Check if port 5253 is in use
netstat -ano | findstr :5253
```

### Frontend won't connect to backend
- Make sure backend is running on port 5253
- Check CORS settings in `Program.cs`
- Verify API_URL in `todoService.js` is correct

### Database issues
```powershell
# Delete database and recreate
Remove-Item todolist.db
dotnet ef database update
```

## 🚀 Future Enhancements

- [ ] User authentication and authorization
- [ ] Todo categories/tags
- [ ] Due dates and reminders
- [ ] Priority levels
- [ ] Search functionality
- [ ] Dark mode
- [ ] Drag and drop to reorder
- [ ] Export todos to CSV/JSON
- [ ] Mobile app version

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 👨‍💻 Author

**Your Name**
- GitHub: [@yourusername](https://github.com/yourusername)
- LinkedIn: [Your Profile](https://linkedin.com/in/yourprofile)

## 🙏 Acknowledgments

- ASP.NET Core Documentation
- React Documentation
- Entity Framework Core Documentation
- Stack Overflow Community

---

**Made with ❤️ using ASP.NET Core + React**

⭐ If you found this project helpful, please give it a star!
