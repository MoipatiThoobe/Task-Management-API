# Task Management API

A RESTful Task Management API built with ASP.NET Core, Entity Framework Core, and Microsoft SQL Server.

The project demonstrates how to build a backend API that performs CRUD (Create, Read, Update, Delete) operations against a relational database using Entity Framework Core.

---

## 📌 Project Overview

The Task Management API allows users to create, retrieve, update, and delete tasks through RESTful HTTP endpoints.

The application was built as part of my practical backend and cloud engineering upskilling, with a focus on understanding:

- ASP.NET Core Web APIs
- RESTful API design
- Entity Framework Core
- Microsoft SQL Server
- Database migrations
- OpenAPI/Swagger documentation
- CRUD operations
- Local development and database integration

The project will be extended in later stages with validation, DTOs, improved error handling, containerisation, and potential cloud deployment.

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# | Programming language |
| ASP.NET Core | Web API framework |
| .NET 10 | Application runtime/framework |
| Entity Framework Core 10 | ORM and database access |
| Microsoft SQL Server | Relational database |
| OpenAPI | API specification |
| Swagger UI | API documentation and testing |
| Git | Version control |
| GitHub | Source code hosting |

---

## 🏗️ Architecture

The current application follows this flow:

```text
Client
  │
  │ HTTP Request
  ▼
ASP.NET Core Web API
  │
  ▼
AppDbContext
  │
  ▼
Entity Framework Core
  │
  ▼
Microsoft SQL Server
  │
  ▼
TaskManagementDB
  │
  ▼
Task Table
```

## Project Structure
The current project structure is:
TaskManagementAPI/
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── TaskItem.cs
│
├── Migrations/
│   ├── *_InitialCreate.cs
│   ├── *_InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── TaskManagementAPI.csproj
└── README.md
The project structure will be improved in later stages as controllers, DTOs and additional application components are introduced. 

## Database
The application uses Microsoft SQL Server as its relational database.

### Database
```
TaskManagementDB
```

### Table 
```
Tasks
```

### Tasks table schema
| Column        | Type        | Description                                        |
| ------------- | ----------- | -------------------------------------------------- |
| `Id`          | `int`       | Primary key and automatically generated identifier |
| `Title`       | `nvarchar`  | Task title                                         |
| `Description` | `nvarchar`  | Task description                                   |
| `IsCompleted` | `bit`       | Indicates whether the task has been completed      |
| `CreatedAt`   | `datetime2` | Date and time the task was created                 |

