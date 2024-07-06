**Domain** will have only interface,entities,businesslogic 
**API/Controller** will have reference of infra,application layer
**APPLICATION** layer have reference to domain 
**Infra** will have reference to application 


TodoApp
├── TodoApp.sln
└── src
    ├── TodoApp.Domain
    │   ├── Entities
    │   │   └── TodoItem.cs
    │   ├── Interfaces
    │   │   └── ITodoRepository.cs
    │   └── TodoApp.Domain.csproj
    ├── TodoApp.Application
    │   ├── Services
    │   │   └── TodoService.cs
    │   └── TodoApp.Application.csproj
    ├── TodoApp.Infrastructure
    │   ├── Data
    │   │   └── TodoContext.cs
    │   ├── Repositories
    │   │   └── TodoRepository.cs
    │   └── TodoApp.Infrastructure.csproj
    └── TodoApp.API
        ├── Controllers
        │   └── TodoController.cs
        ├── appsettings.json
        ├── Program.cs
        ├── Startup.cs 
        └── TodoApp.API.csproj

![image](https://github.com/shreekant89/NET-OLD/assets/25607735/3c86a1a1-63fe-4854-8490-58edae2a48e4)



        
