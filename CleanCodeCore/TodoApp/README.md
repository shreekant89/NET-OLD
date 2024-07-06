create project first:---------------------

mkdir TodoApp
cd TodoApp
dotnet new sln -n TodoApp
mkdir src
cd src
dotnet new classlib -n TodoApp.Core
dotnet new classlib -n TodoApp.Infrastructure
dotnet new webapi -n TodoApp.API
cd ..
dotnet sln add src/TodoApp.Core/TodoApp.Core.csproj
dotnet sln add src/TodoApp.Infrastructure/TodoApp.Infrastructure.csproj
dotnet sln add src/TodoApp.API/TodoApp.API.csproj
cd src/TodoApp.API
dotnet add reference ../TodoApp.Core/TodoApp.Core.csproj
dotnet add reference ../TodoApp.Infrastructure/TodoApp.Infrastructure.csproj


add pakcages:---

dotnet add src/TodoApp.Core package Microsoft.EntityFrameworkCore
dotnet add src/TodoApp.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/TodoApp.Infrastructure package Microsoft.EntityFrameworkCore.Tools

use code first approach:--------------generate db from code
dotnet ef migrations add InitialCreate -p src/TodoApp.Infrastructure -s src/TodoApp.API
dotnet ef database update -p src/TodoApp.Infrastructure -s src/TodoApp.API


\---TodoApp
    |   README.md
    |   TodoApp.sln
    |
    \---src
        +---TodoApp.API
        |   |   appsettings.Development.json
        |   |   appsettings.json
        |   |   Program.cs
        |   |   TodoApp.API.csproj
        |   |   TodoApp.API.csproj.user
        |   |   TodoApp.API.http
        |   |
        |   +---Controllers
        |   |       TodoController.cs
        |   |
        |   \---Properties
        |           launchSettings.json
        |
        +---TodoApp.Core
        |   |   TodoApp.Core.csproj
        |   |
        |   +---Entities
        |   |       TodoItem.cs
        |   |
        |   +---Interfaces
        |   |       ITodoRepository.cs
        |
        \---TodoApp.Infrastructure
            |   TodoApp.Infrastructure.csproj
            |
            +---Data
            |       TodoContext.cs
            |
            +---Migrations
            |       20240706084130_InitialCreate.cs
            |       20240706084130_InitialCreate.Designer.cs
            |       TodoContextModelSnapshot.cs
            |
            \---Repositories
                    TodoRepository.cs